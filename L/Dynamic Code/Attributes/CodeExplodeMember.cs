using System;

namespace LCore.Dynamic
    {
    internal abstract class CodeExplodeMember : Attribute
        {
        public string MethodName;
        public string Comments;
        public bool ExecuteResult;
        public string[] ParameterNames;

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
