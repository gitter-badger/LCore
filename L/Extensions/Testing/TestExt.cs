using System;
using System.Collections.Generic;
using LCore.Dynamic;
using LCore.ObjectExtensions;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LCore.UnitTesting
{
    public static class TestExt
    {

        #region AssertSucceedes
        public static void MethodAssertSucceedes(this MethodInfo Method)
        {
            Method.MethodAssertSucceedes<Object>((Object[])null, (Func<Object, Boolean>[])null);
        }

        public static void MethodAssertSucceedes(this MethodInfo Method, Object[] Params = null)
        {
            Method.MethodAssertSucceedes<Object>(Params, (Func<Object, Boolean>[])null);
        }

        public static void MethodAssertSucceedes(this MethodInfo Method, Object[] Params = null, params Func<Boolean>[] AdditionalChecks)
        {
            Method.MethodAssertSucceedes<Object>(Params, AdditionalChecks.Convert((f) =>
            {
                return f.Arg<Object, Boolean>();
            }));
        }

        public static void MethodAssertSucceedes(this MethodInfo Method, Object[] Params = null, params Func<Object, Boolean>[] AdditionalChecks)
        {
            Method.MethodAssertSucceedes<Object>(Params, AdditionalChecks);
        }

        public static void MethodAssertSucceedes<U>(this MethodInfo Method, Object[] Params = null, params Func<Boolean>[] AdditionalResultChecks)
        {
            Method.MethodAssertSucceedes<U>(Params, AdditionalResultChecks.Convert((f) =>
            {
                return f.Arg<U, Boolean>();
            }));
        }

        public static void MethodAssertSucceedes<U>(this MethodInfo Method, Object[] Params = null, params Func<U, Boolean>[] AdditionalResultChecks)
        {
            Params = Params ?? new Object[] { };
            U Result = (U)Method.Invoke(null, Params);

            AdditionalResultChecks.Each((check) =>
            {
                if (!check(Result))
                    throw new Exception("Result did not pass additional checks." + Result.ToS());
            });
        }

        public static void AssertSucceedes(this Action Act)
        {
            Act.Method.MethodAssertSucceedes();
        }

        public static void AssertSucceedes<T1>(this Action<T1> Act, T1 o1)
        {
            Act.Method.MethodAssertSucceedes(new Object[] { o1 });
        }

        public static void AssertSucceedes<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
        {
            Act.Method.MethodAssertSucceedes(new Object[] { o1, o2 });
        }

        public static void AssertSucceedes<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
        {
            Act.Method.MethodAssertSucceedes(new Object[] { o1, o2, o3 });
        }

        public static void AssertSucceedes<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
        {
            Act.Method.MethodAssertSucceedes(new Object[] { o1, o2, o3, o4 });
        }

        public static void AssertSucceedes<U>(this Func<U> Func, params Func<Boolean>[] AdditionalChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { }, AdditionalChecks);
        }

        public static void AssertSucceedes<T1, U>(this Func<T1, U> Func, T1 o1, params Func<Boolean>[] AdditionalChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1 }, AdditionalChecks);
        }

        public static void AssertSucceedes<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, params Func<Boolean>[] AdditionalChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1, o2 }, AdditionalChecks);
        }

        public static void AssertSucceedes<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, params Func<Boolean>[] AdditionalChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1, o2, o3 }, AdditionalChecks);
        }

        public static void AssertSucceedes<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, params Func<Boolean>[] AdditionalChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1, o2, o3, o4 }, AdditionalChecks);
        }

        public static void AssertSucceedes<U>(this Func<U> Func, params Func<U, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { }, AdditionalResultChecks);
        }

        public static void AssertSucceedes<T1, U>(this Func<T1, U> Func, T1 o1, params Func<U, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1 }, AdditionalResultChecks);
        }

        public static void AssertSucceedes<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, params Func<U, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1, o2 }, AdditionalResultChecks);
        }

        public static void AssertSucceedes<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, params Func<U, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1, o2, o3 }, AdditionalResultChecks);
        }

        public static void AssertSucceedes<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, params Func<U, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertSucceedes(new Object[] { o1, o2, o3, o4 }, AdditionalResultChecks);
        }
        #endregion

        #region AssertFails
        public static void MethodAssertFails<E>(this MethodInfo Method, Object[] Params = null, params Func<Boolean>[] AdditionalChecks) where E : Exception
        {
            Method.MethodAssertFails(Params, typeof(E), AdditionalChecks);
        }

        public static void MethodAssertFails(this MethodInfo Method, Object[] Params = null, Type EType = null, params Func<Boolean>[] AdditionalChecks)
        {
            EType = EType ?? typeof(Exception);

            try
            {
                Params = Params ?? new Object[] { };
                Method.Invoke(null, Params);
            }
            catch (TargetInvocationException e)
            {
                if (!e.InnerException.GetType().IsType(EType))
                    throw new Exception("Exception type " + EType.FullName + " did not throw.\n" + e.InnerException.GetType().FullName + " was thrown instead.");
                return;
            }
            catch (Exception e)
            {
                if (e.IsType(EType))
                    return;

                throw new Exception("Exception type " + EType.FullName + " did not throw.\n" + e.GetType().FullName + " was thrown instead.");
            }

            AdditionalChecks.EachI((i, check) =>
            {
                if (!check())
                    throw new Exception("Method did not pass additional check #" + (i + 1) + ".");
            });

            throw new Exception("Exception type " + EType.FullName + " did not throw.");
        }

        public static void AssertFails(this Action Act)
        {
            Act.Method.MethodAssertFails();
        }

        public static void AssertFails<T1>(this Action<T1> Act, T1 o1)
        {
            Act.Method.MethodAssertFails(new Object[] { o1 });
        }

        public static void AssertFails<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
        {
            Act.Method.MethodAssertFails(new Object[] { o1, o2 });
        }

        public static void AssertFails<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
        {
            Act.Method.MethodAssertFails(new Object[] { o1, o2, o3 });
        }

        public static void AssertFails<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
        {
            Act.Method.MethodAssertFails(new Object[] { o1, o2, o3, o4 });
        }

        public static void AssertFails<E>(this Action Act) where E : Exception
        {
            Act.Method.MethodAssertFails<E>();
        }

        public static void AssertFails<T1, E>(this Action<T1> Act, T1 o1) where E : Exception
        {
            Act.Method.MethodAssertFails<E>(new Object[] { o1 });
        }

        public static void AssertFails<T1, T2, E>(this Action<T1, T2> Act, T1 o1, T2 o2) where E : Exception
        {
            Act.Method.MethodAssertFails<E>(new Object[] { o1, o2 });
        }

        public static void AssertFails<T1, T2, T3, E>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3) where E : Exception
        {
            Act.Method.MethodAssertFails<E>(new Object[] { o1, o2, o3 });
        }

        public static void AssertFails<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
        {
            Act.Method.MethodAssertFails<E>(new Object[] { o1, o2, o3, o4 });
        }

        public static void AssertFails<U>(this Func<U> Func)
        {
            Func.Method.MethodAssertFails();
        }

        public static void AssertFails<T1, U>(this Func<T1, U> Func, T1 o1)
        {
            Func.Method.MethodAssertFails(new Object[] { o1 });
        }

        public static void AssertFails<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
        {
            Func.Method.MethodAssertFails(new Object[] { o1, o2 });
        }

        public static void AssertFails<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
        {
            Func.Method.MethodAssertFails(new Object[] { o1, o2, o3 });
        }

        public static void AssertFails<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
        {
            Func.Method.MethodAssertFails(new Object[] { o1, o2, o3, o4 });
        }

        public static void AssertFails<U, E>(this Func<U> Func) where E : Exception
        {
            Func.Method.MethodAssertFails<E>();
        }

        public static void AssertFails<T1, U, E>(this Func<T1, U> Func, T1 o1) where E : Exception
        {
            Func.Method.MethodAssertFails<E>(new Object[] { o1 });
        }

        public static void AssertFails<T1, T2, U, E>(this Func<T1, T2, U> Func, T1 o1, T2 o2) where E : Exception
        {
            Func.Method.MethodAssertFails<E>(new Object[] { o1, o2 });
        }

        public static void AssertFails<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3) where E : Exception
        {
            Func.Method.MethodAssertFails<E>(new Object[] { o1, o2, o3 });
        }

        public static void AssertFails<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
        {
            Func.Method.MethodAssertFails<E>(new Object[] { o1, o2, o3, o4 });
        }
        #endregion

        #region AssertResult
        public static void MethodAssertResult(this MethodInfo Method, Object[] Params = null, Object ExpectedResult = null, params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Method.MethodAssertResult<Object>(Params, ExpectedResult, AdditionalResultChecks);
        }

        public static void MethodAssertResult<U>(this MethodInfo Method, Object[] Params = null, U ExpectedResult = default(U), params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Params = Params ?? new Object[] { };

            Exception Error = null;
            U Actual = default(U);
            try
            {
                Actual = (U)Method.Invoke(null, Params);
            }
            catch (Exception e)
            {
                Error = e;
            }

            Boolean Passed = true;
            if (ExpectedResult is IEnumerable && Actual is IEnumerable)
            {
                Passed = Passed && ((IEnumerable)ExpectedResult).Equivalent((IEnumerable)Actual);
                if (!Passed)
                {
                }
            }
            else
                if (ExpectedResult is IComparable && Actual is IComparable)
                {
                    Passed = Passed && ((IComparable)ExpectedResult).CompareTo((IComparable)Actual) == 0;
                    if (!Passed)
                    {
                    }
                }
                else
                    if (Error != null && !(ExpectedResult is Exception))
                    {
                        Passed = false;
                    }
                    else
                    {
                        String Details1 = ExpectedResult.Details();
                        String Details2;

                        if (Error == null)
                            Details2 = Actual.Details();
                        else
                            Details2 = Error.Details();

                        Passed = Details1 == Details2;
                        //throw new Exception("Could not determine if result matched expected. \n" + ExpectedResult.Type().ToS());
                    }

            if (Actual is U)
            {
                AdditionalResultChecks.Each((check) =>
                {
                    Passed = Passed && check((U)Actual);
                    if (!Passed)
                    {
                        String s = "";
                        try
                        {
                            s = "Result did not pass additional checks.\n Params:\n " +
                            Params.CollectStr((i, p) =>
                            {
                                try
                                {
                                    return p.ToS() + "\n";
                                }
                                catch
                                {
                                    return "null\n";
                                }
                            }) + "\nExpected: '" + ExpectedResult.ToS() + "'\nActual: '" + ((Object)Error ?? (Object)Actual).ToS() + "'";
                        }
                        catch
                        {
                            s = "Result did not pass additional checks.";
                        }

                        throw new Exception(s.ReplaceAll("\r", ""));
                    }
                });
            }


            if (!Passed)
            {
                String s = "";
                try
                {
                    s = "Result did not match value. \nParams:\n " +
                    Params.CollectStr((i, p) =>
                    {
                        try
                        {
                            return p.ToS() + "\n";
                        }
                        catch
                        {
                            return "null\n";
                        }
                    }) +
                    "\n\nExpected: '" + ExpectedResult.ToS() +
                    "'\nActual: '" + ((Object)Error ?? (Object)Actual).ToS() + "'";
                }
                catch
                {
                    s = "Result did not match value.";
                }
                throw new Exception(s.ReplaceAll("\r", ""));
            }
        }

        public static void AssertResult<U>(this Func<U> Func, U ExpectedResult, params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertResult<U>(new Object[] { }, ExpectedResult, AdditionalResultChecks);
        }

        public static void AssertResult<T1, U>(this Func<T1, U> Func, T1 o1, U ExpectedResult, params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertResult<U>(new Object[] { o1 }, ExpectedResult, AdditionalResultChecks);
        }

        public static void AssertResult<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, U ExpectedResult, params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertResult<U>(new Object[] { o1, o2 }, ExpectedResult, AdditionalResultChecks);
        }

        public static void AssertResult<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, U ExpectedResult, params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertResult<U>(new Object[] { o1, o2, o3 }, ExpectedResult, AdditionalResultChecks);
        }

        public static void AssertResult<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, U ExpectedResult, params Func<Object, Boolean>[] AdditionalResultChecks)
        {
            Func.Method.MethodAssertResult<U>(new Object[] { o1, o2, o3, o4 }, ExpectedResult, AdditionalResultChecks);
        }
        #endregion

        #region AssertSource
        public static void MethodAssertSource(this MethodInfo Method, Object[] Params = null, Object ExpectedSource = null, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Method.MethodAssertSource<Object>(Params, ExpectedSource, AdditionalSourceChecks);
        }

        public static void MethodAssertSource<U>(this MethodInfo Method, Object[] Params = null, U ExpectedSource = default(U), params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Params = Params ?? new Object[] { };

            U Source = (U)Params[0];


            Method.Invoke(null, Params);

            Boolean Passed = true;
            if (ExpectedSource == null)
                ;
            else
                if (ExpectedSource is IEnumerable)
                    Passed = Passed && ((IEnumerable)ExpectedSource).Equivalent((IEnumerable)Source);
                else
                    if (ExpectedSource is IComparable)
                        Passed = Passed && ((IComparable)ExpectedSource).CompareTo((IComparable)Source) == 0;
                    else
                    {
                        String Details1 = ExpectedSource.Details();
                        String Details2 = Source.Details();

                        Passed = Details1 == Details2;

                        // throw new Exception("Could not determine if result matched expected. " + ExpectedSource.Type().ToS());
                    }

            AdditionalSourceChecks.Each((check) =>
            {
                Passed = Passed && check(Source);
                if (!Passed)
                    throw new Exception("Result did not pass additional checks.\nExpected: " + ExpectedSource.ToS() + "\nActual: " + Source.ToS());
            });

            if (!Passed)
                throw new Exception("Result did not match value.\nExpected: " + ExpectedSource.ToS() + "\nActual: " + Source.ToS());
        }

        public static void AssertSource<T1>(this Action<T1> Act, T1 o1, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Act.Method.MethodAssertSource(new Object[] { o1 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Act.Method.MethodAssertSource(new Object[] { o1, o2 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Act.Method.MethodAssertSource(new Object[] { o1, o2, o3 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Act.Method.MethodAssertSource(new Object[] { o1, o2, o3, o4 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, U>(this Func<T1, U> Func, T1 o1, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Func.Method.MethodAssertSource<T1>(new Object[] { o1 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Func.Method.MethodAssertSource<T1>(new Object[] { o1, o2 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Func.Method.MethodAssertSource<T1>(new Object[] { o1, o2, o3 }, ExpectedSource, AdditionalSourceChecks);
        }

        public static void AssertSource<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, T1 ExpectedSource, params Func<Object, Boolean>[] AdditionalSourceChecks)
        {
            Func.Method.MethodAssertSource<T1>(new Object[] { o1, o2, o3, o4 }, ExpectedSource, AdditionalSourceChecks);
        }
        #endregion

        public static int RunUnitTests(this Type t)
        {
            int TestsRan = 0;

            Dictionary<MemberInfo, List<TestAttribute>> Tests = t.GetTestMembers();

            Tests.Each((tests) =>
            {
                int CurrentTest = 1;
                try
                {
                    if (tests.Key is MethodInfo)
                    {

                        tests.Value.Each((test) =>
                        {
                            MethodInfo m = (MethodInfo)tests.Key;

                            if (m.ContainsGenericParameters)
                            {
                                TestMethodGenerics Generics = m.MemberGetAttribute<TestMethodGenerics>(false);

                                if (!test.GenericTypes.IsEmpty())
                                {
                                    m = m.MakeGenericMethod(test.GenericTypes);
                                }
                                else
                                    if (Generics != null)
                                    {
                                        m = m.MakeGenericMethod(Generics.GenericTypes);
                                    }
                                    else
                                    {
                                        throw new Exception("Unable to find generics for Test Attribute");
                                    }
                            }

                            test.FixParameterTypes(m);
                            test.RunTest(m);

                            TestsRan++;
                            CurrentTest++;
                        });
                    }
                    else
                        throw new Exception("Member " + tests.Key.Name + " is not a method.");
                }
                catch (Exception e)
                {
                    throw new Exception("Testing for Member: " + tests.Key.Name + " Test #" + CurrentTest + " failed.\n" + e.ToS(), e);
                }
            });

            return TestsRan;
        }

        public static Dictionary<MemberInfo, List<TestAttribute>> GetTestMembers(this Type t)
        {
            Dictionary<MemberInfo, List<TestAttribute>> Tests = new Dictionary<MemberInfo, List<TestAttribute>>();

            t.GetMembers().Each((m) =>
            {
                if (!(m is MethodInfo) || !(m as MethodInfo).IsStatic)
                {
                    return;
                }

                if (!Tests.ContainsKey(m))
                    Tests.Add(m, new List<TestAttribute>());

                m.MemberGetAttributes<TestAttribute>(false).Each((attr) =>
                {
                    Tests[m].Add(attr);
                });
            });

            return Tests;
        }
    }
}