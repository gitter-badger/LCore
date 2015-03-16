using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Runtime.Serialization;

namespace LCore
{
    public partial class Logic
    {
        public static Action<Exception> DefaultExceptionHandler = L.Arg<Exception>();

        #region Base Lambdas
        #region Exception
        public static Func<Exception, String> Exception_GetMessage = (e) => { return e.Message; };
        public static Func<Exception, IDictionary> Exception_GetData = (e) => { return e.Data; };
        public static Func<Exception, Exception> Exception_GetInnerException = (e) => { return e.InnerException; };
        public static Func<Exception, MethodBase> Exception_GetTargetSite = (e) => { return e.TargetSite; };
        public static Func<Exception, String> Exception_GetStackTrace = (e) => { return e.StackTrace; };
        public static Func<Exception, String> Exception_GetHelpLink = (e) => { return e.HelpLink; };
        public static Action<Exception, String> Exception_SetHelpLink = (e, s) => { e.HelpLink = s; };
        public static Func<Exception, String> Exception_GetSource = (e) => { return e.Source; };
        public static Action<Exception, String> Exception_SetSource = (e, s) => { e.Source = s; };
        public static Func<Exception, Exception> Exception_GetBaseException = (e) => { return e.GetBaseException(); };
        public static Func<Exception, String> Exception_ToString = (e) => { return e.ToString(); };
        public static Action<Exception, SerializationInfo, StreamingContext> Exception_GetObjectData = (e, info, context) => { e.GetObjectData(info, context); };
        public static Func<Exception, Type> Exception_GetType = (e) => { return e.GetType(); };
        public static Func<Exception> Exception_New = () => { return new Exception(); };
        public static Func<String, Exception> Exception_New2 = (message) => { return new Exception(message); };
        public static Func<String, Exception, Exception> Exception_New3 = (message, innerException) => { return new Exception(message, innerException); };
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #endregion

        #region Exceptions
        public static Action Fail = () => { throw new Exception(); };
        public static Action<String> Throw = (s) => { throw new Exception(s); };
        public static Action<String, Exception> Report = (s, e) => { throw new Exception(s, e); };
        public static Action<Exception> ReportEmpty = (e) => { throw new Exception("", e); };
        #endregion
    }
    public static class ExceptionExt
    {
        // Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        #region Try
        public static Func<Boolean> Try(this Action In)
        {
            return () => { try { In(); return true; } catch { return false; } };
        }
        public static Func<T1, Boolean> Try<T1>(this Action<T1> In)
        {
            return (o) => { try { In(o); return true; } catch { return false; } };
        }
        public static Func<T1, T2, Boolean> Try<T1, T2>(this Action<T1, T2> In)
        {
            return (o1, o2) => { try { In(o1, o2); return true; } catch { return false; } };
        }
        public static Func<T1, T2, T3, Boolean> Try<T1, T2, T3>(this Action<T1, T2, T3> In)
        {
            return (o1, o2, o3) => { try { In(o1, o2, o3); return true; } catch { return false; } };
        }
        public static Func<T1, T2, T3, T4, Boolean> Try<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In)
        {
            return (o1, o2, o3, o4) => { try { In(o1, o2, o3, o4); return true; } catch { return false; } };
        }
        public static Func<U> Try<U>(this Func<U> In)
        {
            return () => { try { return In(); } catch { return default(U); } };
        }
        public static Func<T1, U> Try<T1, U>(this Func<T1, U> In)
        {
            return (o) => { try { return In(o); } catch { return default(U); } };
        }
        public static Func<T1, T2, U> Try<T1, T2, U>(this Func<T1, T2, U> In)
        {
            return (o1, o2) => { try { return In(o1, o2); } catch { return default(U); } };
        }
        public static Func<T1, T2, T3, U> Try<T1, T2, T3, U>(this Func<T1, T2, T3, U> In)
        {
            return (o1, o2, o3) => { try { return In(o1, o2, o3); } catch { return default(U); } };
        }
        public static Func<T1, T2, T3, T4, U> Try<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In)
        {
            return (o1, o2, o3, o4) => { try { return In(o1, o2, o3, o4); } catch { return default(U); } };
        }
        #endregion
        // Catches exceptions of all types, using Exception as the base type.
        #region Catch All
        public static Action Catch(this Action In, Action<Exception> Catch)
        {
            return In.Catch<Exception>(Catch);
        }
        public static Action<T1> Catch<T1>(this Action<T1> In, Action<Exception> Catch)
        {
            return In.Catch<T1, Exception>(Catch);
        }
        public static Action<T1, T2> Catch<T1, T2>(this Action<T1, T2> In, Action<Exception> Catch)
        {
            return In.Catch<T1, T2, Exception>(Catch);
        }
        public static Action<T1, T2, T3> Catch<T1, T2, T3>(this Action<T1, T2, T3> In, Action<Exception> Catch)
        {
            return In.Catch<T1, T2, T3, Exception>(Catch);
        }
        public static Action<T1, T2, T3, T4> Catch<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Action<Exception> Catch)
        {
            return In.Catch<T1, T2, T3, T4, Exception>(Catch);
        }
        public static Func<U> Catch<U>(this Func<U> In, Action<Exception> Catch)
        {
            return In.Catch<U, Exception>(Catch);
        }
        public static Func<T1, U> Catch<T1, U>(this Func<T1, U> In, Action<Exception> Catch)
        {
            return In.Catch<T1, U, Exception>(Catch);
        }
        public static Func<T1, T2, U> Catch<T1, T2, U>(this Func<T1, T2, U> In, Action<Exception> Catch)
        {
            return In.Catch<T1, T2, U, Exception>(Catch);
        }
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Action<Exception> Catch)
        {
            return In.Catch<T1, T2, T3, U, Exception>(Catch);
        }
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Action<Exception> Catch)
        {
            return In.Catch<T1, T2, T3, T4, U, Exception>(Catch);
        }
        #endregion
        // Catches exceptions of any type. Takes the error handler as an parameter.
        #region Catch
        public static Action Catch<E>(this Action In, Action<E> Catch) where E : Exception
        {
            return () => { try { In(); } catch (E e) { Catch(e); } };
        }
        public static Action<T1> Catch<T1, E>(this Action<T1> In, Action<E> Catch) where E : Exception
        {
            return (o) => { try { In(o); } catch (E e) { Catch(e); } };
        }
        public static Action<T1, T2> Catch<T1, T2, E>(this Action<T1, T2> In, Action<E> Catch) where E : Exception
        {
            return (o1, o2) => { try { In(o1, o2); } catch (E e) { Catch(e); } };
        }
        public static Action<T1, T2, T3> Catch<T1, T2, T3, E>(this Action<T1, T2, T3> In, Action<E> Catch) where E : Exception
        {
            return (o1, o2, o3) => { try { In(o1, o2, o3); } catch (E e) { Catch(e); } };
        }
        public static Action<T1, T2, T3, T4> Catch<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In, Action<E> Catch) where E : Exception
        {
            return (o1, o2, o3, o4) => { try { In(o1, o2, o3, o4); } catch (E e) { Catch(e); } };
        }
        public static Func<U> Catch<U, E>(this Func<U> In, Action<E> Catch) where E : Exception
        {
            return () => { try { return In(); } catch (E e) { Catch(e); return default(U); } };
        }
        public static Func<T1, U> Catch<T1, U, E>(this Func<T1, U> In, Action<E> Catch) where E : Exception
        {
            return (o) => { try { return In(o); } catch (E e) { Catch(e); return default(U); } };
        }
        public static Func<T1, T2, U> Catch<T1, T2, U, E>(this Func<T1, T2, U> In, Action<E> Catch) where E : Exception
        {
            return (o1, o2) => { try { return In(o1, o2); } catch (E e) { Catch(e); return default(U); } };
        }
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, Action<E> Catch) where E : Exception
        {
            return (o1, o2, o3) => { try { return In(o1, o2, o3); } catch (E e) { Catch(e); return default(U); } };
        }
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, Action<E> Catch) where E : Exception
        {
            return (o1, o2, o3, o4) => { try { return In(o1, o2, o3, o4); } catch (E e) { Catch(e); return default(U); } };
        }
        public static Func<U> Catch<U, E>(this Func<U> In, Func<E, U> Catch) where E : Exception
        {
            return () => { try { return In(); } catch (E e) { return Catch(e); } };
        }
        public static Func<T1, U> Catch<T1, U, E>(this Func<T1, U> In, Func<E, U> Catch) where E : Exception
        {
            return (o) => { try { return In(o); } catch (E e) { return Catch(e); } };
        }
        public static Func<T1, T2, U> Catch<T1, T2, U, E>(this Func<T1, T2, U> In, Func<E, U> Catch) where E : Exception
        {
            return (o1, o2) => { try { return In(o1, o2); } catch (E e) { return Catch(e); } };
        }
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, Func<E, U> Catch) where E : Exception
        {
            return (o1, o2, o3) => { try { return In(o1, o2, o3); } catch (E e) { return Catch(e); } };
        }
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, Func<E, U> Catch) where E : Exception
        {
            return (o1, o2, o3, o4) => { try { return In(o1, o2, o3, o4); } catch (E e) { return Catch(e); } };
        }
        #endregion
        // Catches exceptions of any type. No handler is passed, the error is ignored.
        #region Catch Empty
        public static Action Catch<E>(this Action In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Action<T1> Catch<T1, E>(this Action<T1> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Action<T1, T2> Catch<T1, T2, E>(this Action<T1, T2> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Action<T1, T2, T3> Catch<T1, T2, T3, E>(this Action<T1, T2, T3> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Action<T1, T2, T3, T4> Catch<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Func<U> Catch<U, E>(this Func<U> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Func<T1, U> Catch<T1, U, E>(this Func<T1, U> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Func<T1, T2, U> Catch<T1, T2, U, E>(this Func<T1, T2, U> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In) where E : Exception
        {
            return In.Catch(L.A<E>());
        }
        #endregion
        // Retries the method a specified number of times
        #region Retry
        public static Action Retry(this Action In, int Tries)
        {
            return () =>
            {
                while (true)
                {
                    try
                    {
                        In();
                        return;
                    }
                    catch (Exception e)
                    {
                        if (Tries > 0)
                        {
                            Tries--;
                            continue;
                        }
                        throw new Exception("", e);
                    }
                }
            };
        }
        public static Action<T> Retry<T>(this Action<T> In, int Tries)
        {
            return (o) => { In.Supply(o).Retry(Tries)(); };
        }
        public static Action<T1, T2> Retry<T1, T2>(this Action<T1, T2> In, int Tries)
        {
            return (o1, o2) => { In.Supply(o1, o2).Retry(Tries)(); };
        }
        public static Action<T1, T2, T3> Retry<T1, T2, T3>(this Action<T1, T2, T3> In, int Tries)
        {
            return (o1, o2, o3) => { In.Supply(o1, o2, o3).Retry(Tries)(); };
        }
        public static Action<T1, T2, T3, T4> Retry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, int Tries)
        {
            return (o1, o2, o3, o4) => { In.Supply(o1, o2, o3, o4).Retry(Tries)(); };
        }
        public static Func<U> Retry<U>(this Func<U> In, int Tries)
        {
            return () =>
            {
                while (true)
                {
                    try
                    {
                        return In();
                    }
                    catch (Exception e)
                    {
                        if (Tries > 0)
                        {
                            Tries--;
                            continue;
                        }
                        throw new Exception("", e);
                    }
                }
            };
        }
        public static Func<T1, U> Retry<T1, U>(this Func<T1, U> In, int Tries)
        {
            return (o) => { return In.Supply(o).Retry(Tries)(); };
        }
        public static Func<T1, T2, U> Retry<T1, T2, U>(this Func<T1, T2, U> In, int Tries)
        {
            return (o1, o2) => { return In.Supply(o1, o2).Retry(Tries)(); };
        }
        public static Func<T1, T2, T3, U> Retry<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, int Tries)
        {
            return (o1, o2, o3) => { return In.Supply(o1, o2, o3).Retry(Tries)(); };
        }
        public static Func<T1, T2, T3, T4, U> Retry<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, int Tries)
        {
            return (o1, o2, o3, o4) => { return In.Supply(o1, o2, o3, o4).Retry(Tries)(); };
        }
        #endregion
        // If an exception occurs, another exception is thrown that includes parameter data.
        #region Debug
        public static Action<T1> Debug<T1>(this Action<T1> In)
        {
            return (o1) => { In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1 })))(o1); };
        }
        public static Action<T1, T2> Debug<T1, T2>(this Action<T1, T2> In)
        {
            return (o1, o2) => { In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1, o2 })))(o1, o2); };
        }
        public static Action<T1, T2, T3> Debug<T1, T2, T3>(this Action<T1, T2, T3> In)
        {
            return (o1, o2, o3) => { In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1, o2, o3 })))(o1, o2, o3); };
        }
        public static Action<T1, T2, T3, T4> Debug<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In)
        {
            return (o1, o2, o3, o4) => { In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1, o2, o3, o4 })))(o1, o2, o3, o4); };
        }
        public static Func<U> Debug<U>(this Func<U> In)
        {
            return () => { return In.Catch(L.ReportEmpty)(); };
        }
        public static Func<T1, U> Debug<T1, U>(this Func<T1, U> In)
        {
            return (o1) => { return In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1 })))(o1); };
        }
        public static Func<T1, T2, U> Debug<T1, T2, U>(this Func<T1, T2, U> In)
        {
            return (o1, o2) => { return In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1, o2 })))(o1, o2); };
        }
        public static Func<T1, T2, T3, U> Debug<T1, T2, T3, U>(this Func<T1, T2, T3, U> In)
        {
            return (o1, o2, o3) => { return In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1, o2, o3 })))(o1, o2, o3); };
        }
        public static Func<T1, T2, T3, T4, U> Debug<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In)
        {
            return (o1, o2, o3, o4) => { return In.Catch(L.Report.Supply(L.Objects_ToString(new Object[] { o1, o2, o3, o4 })))(o1, o2, o3, o4); };
        }
        #endregion
        // Appends an empty exception to the current method.
        #region Fail
        public static Action Fail(this Action In)
        {
            return In.Merge(L.Fail);
        }
        public static Action<T> Fail<T>(this Action<T> In)
        {
            return In.Merge(L.Fail);
        }
        public static Action<T1, T2> Fail<T1, T2>(this Action<T1, T2> In)
        {
            return In.Merge(L.Fail);
        }
        public static Action<T1, T2, T3> Fail<T1, T2, T3>(this Action<T1, T2, T3> In)
        {
            return In.Merge(L.Fail);
        }
        public static Action<T1, T2, T3, T4> Fail<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In)
        {
            return In.Merge(L.Fail);
        }
        public static Func<U> Fail<U>(this Func<U> In)
        {
            return In.Merge(L.Fail);
        }
        public static Func<T, U> Fail<T, U>(this Func<T, U> In)
        {
            return In.Merge(L.Fail);
        }
        public static Func<T1, T2, U> Fail<T1, T2, U>(this Func<T1, T2, U> In)
        {
            return In.Merge(L.Fail);
        }
        public static Func<T1, T2, T3, U> Fail<T1, T2, T3, U>(this Func<T1, T2, T3, U> In)
        {
            return In.Merge(L.Fail);
        }
        public static Func<T1, T2, T3, T4, U> Fail<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In)
        {
            return In.Merge(L.Fail);
        }
        #endregion
        // Appends an exception to the current method, adding a message.
        #region Throw
        public static Action Throw(this Action In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Action<T> Throw<T>(this Action<T> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Action<T1, T2> Throw<T1, T2>(this Action<T1, T2> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Action<T1, T2, T3> Throw<T1, T2, T3>(this Action<T1, T2, T3> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Action<T1, T2, T3, T4> Throw<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Func<U> Throw<U>(this Func<U> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Func<T, U> Throw<T, U>(this Func<T, U> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Func<T1, T2, U> Throw<T1, T2, U>(this Func<T1, T2, U> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Func<T1, T2, T3, U> Throw<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        public static Func<T1, T2, T3, T4, U> Throw<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String Message)
        {
            return In.Merge(L.Throw.Supply(Message));
        }
        #endregion
        // Catches exceptions of any type and reports a new Exception with a message attached.
        #region Report
        public static Action Report<E>(this Action In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Action<T> Report<T, E>(this Action<T> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Action<T1, T2> Report<T1, T2, E>(this Action<T1, T2> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Action<T1, T2, T3> Report<T1, T2, T3, E>(this Action<T1, T2, T3> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Action<T1, T2, T3, T4> Report<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Func<U> Report<U, E>(this Func<U> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Func<T, U> Report<T, U, E>(this Func<T, U> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Func<T1, T2, U> Report<T1, T2, U, E>(this Func<T1, T2, U> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Func<T1, T2, T3, U> Report<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        public static Func<T1, T2, T3, T4, U> Report<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, String Message, E e) where E : Exception
        {
            return In.Merge(L.Report.Supply(Message, e));
        }
        #endregion
        // Catches exceptions of any type and reports a new Exception with no message attached.
        #region Report Empty
        public static Action Report<E>(this Action In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Action<T> Report<T, E>(this Action<T> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Action<T1, T2> Report<T1, T2, E>(this Action<T1, T2> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Action<T1, T2, T3> Report<T1, T2, T3, E>(this Action<T1, T2, T3> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Action<T1, T2, T3, T4> Report<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Func<U> Report<U, E>(this Func<U> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Func<T, U> Report<T, U, E>(this Func<T, U> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Func<T1, T2, U> Report<T1, T2, U, E>(this Func<T1, T2, U> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Func<T1, T2, T3, U> Report<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        public static Func<T1, T2, T3, T4, U> Report<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, E e) where E : Exception
        {
            return In.Merge(L.ReportEmpty.Supply(e));
        }
        #endregion
        // Handle catches all exceptions, directing them to the Default Exception Handler, which you can customize.
        #region Handle
        public static Action Handle(this Action In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Action<T1> Handle<T1>(this Action<T1> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Action<T1, T2> Handle<T1, T2>(this Action<T1, T2> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Action<T1, T2, T3> Handle<T1, T2, T3>(this Action<T1, T2, T3> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Action<T1, T2, T3, T4> Handle<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Func<U> Handle<U>(this Func<U> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Func<T1, U> Handle<T1, U>(this Func<T1, U> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Func<T1, T2, U> Handle<T1, T2, U>(this Func<T1, T2, U> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Func<T1, T2, T3, U> Handle<T1, T2, T3, U>(this Func<T1, T2, T3, U> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        public static Func<T1, T2, T3, T4, U> Handle<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In)
        {
            return In.Catch(L.DefaultExceptionHandler);
        }
        #endregion
    }
}