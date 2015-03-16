using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Threading;
using LCore;
using LCore.Dynamic;

namespace LCore
    {
    public class ExceptionList : Exception
        {
        public static implicit operator List<Exception>(ExceptionList O)
            {
            return O.Exceptions;
            }
        public static implicit operator ExceptionList(List<Exception> E)
            {
            return new ExceptionList(E);
            }

        public List<Exception> Exceptions { get; set; }

        public ExceptionList(IEnumerable<Exception> Exceptions)
            {
            this.Exceptions = Exceptions.List();
            }

        public override string Message
            {
            get
                {
                return Exceptions.Convert(L.Exception_GetMessage).JoinLines();
                }
            }

        public override string StackTrace
            {
            get
                {
                return Exceptions.Convert(L.Exception_GetStackTrace).JoinLines();
                }
            }
        }
    }