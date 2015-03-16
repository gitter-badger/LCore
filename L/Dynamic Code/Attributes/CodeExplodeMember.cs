using System;
using System.Collections.Generic;
using System.Text;

namespace LCore.Dynamic
    {
    public abstract class CodeExplodeMember : Attribute
        {
        public String MethodName = "";
        public String Comments = "";
        public Boolean ExecuteResult = false;
        public String[] ParameterNames = new String[] {};

        public CodeExplodeMember(String MethodName, String Comments = "")
            : this(MethodName, new String[] { }, Comments)
            {
            }
        public CodeExplodeMember(String MethodName, String[] ParameterNames, String Comments = "", Boolean ExecuteResult = false)
            {
            this.MethodName = MethodName;
            this.Comments = Comments;
            this.ParameterNames = ParameterNames;
            this.ExecuteResult = ExecuteResult;
            }
        }
    }
