using System;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal abstract class CodeExplodeMember : Attribute, ISubClassPersistentAttribute
        {
        public readonly string MethodName;
        public readonly string Comments;
        public readonly bool ExecuteResult;
        public readonly string[] ParameterNames;

        protected CodeExplodeMember(string MethodName, string Comments = "")
            : this(MethodName, new string[] { }, Comments)
            {
            }

        protected CodeExplodeMember(string MethodName, string[] ParameterNames, string Comments = "", bool ExecuteResult = false)
            {
            this.MethodName = MethodName;
            this.Comments = Comments;
            this.ParameterNames = ParameterNames;
            this.ExecuteResult = ExecuteResult;
            }
        }
    }
