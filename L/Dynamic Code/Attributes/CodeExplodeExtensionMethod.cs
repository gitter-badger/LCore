using System;

namespace LCore.Dynamic
    {
    /// <summary>
    /// Explodes a Method providing the method as an extension method on its type
    /// </summary>
    internal class CodeExplodeExtensionMethod : CodeExplodeMember
        {
        public readonly bool ExtendExplosions;

        public CodeExplodeExtensionMethod(string MethodName, string Comments = "", bool ExtendExplosions = false)
            : base(MethodName, Comments)
			{
			this.ExtendExplosions = ExtendExplosions;
            }
        public CodeExplodeExtensionMethod(string MethodName, string[] ParameterNames, string Comments = "", bool ExecuteResult = false, bool ExtendExplosions = false)
            : base(MethodName, ParameterNames, Comments, ExecuteResult)
            {
            this.ExtendExplosions = ExtendExplosions;
            }
        }
    }
