using System;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Tools
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

        public override string Message => this.Exceptions.Convert(e => e.Message).JoinLines();

        public override string StackTrace => this.Exceptions.Convert(e => e.StackTrace).JoinLines();
        }
    }