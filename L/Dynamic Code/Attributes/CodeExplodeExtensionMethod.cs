using System;
using System.Collections.Generic;

namespace LCore.Dynamic
    {
    public class CodeExplodeExtensionMethod : CodeExplodeMember
        {
        public Boolean ExtendExplosions = false;

        public CodeExplodeExtensionMethod(String MethodName, String Comments = "", Boolean ExtendExplosions = false)
            : base(MethodName, Comments)
			{
			this.ExtendExplosions = ExtendExplosions;
            }
        public CodeExplodeExtensionMethod(String MethodName, String[] ParameterNames, String Comments = "", Boolean ExecuteResult = false, Boolean ExtendExplosions = false)
            : base(MethodName, ParameterNames, Comments, ExecuteResult)
            {
            this.ExtendExplosions = ExtendExplosions;
            }
        }
    }
