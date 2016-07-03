using System;
using System.Reflection;

using LCore.Extensions;
using LCore.Tools;

namespace LCore.Dynamic
    {
    internal class CodeExplode_ExplodeLogic : CodeExplode
        {
        /// <summary>
        /// One for methods with 0 parameters, 16 for methods up to 16 parameters.
        /// </summary>
        public const int ExplodeCount = 17;

        public override string ExplodeCode(Lists<string, MemberInfo> t)
            {
            CodeExploder.DeclaredExtensionCache.Clear();

            return L.Exploder.LogicMemberInfo_Explode(t);
            }
        public override bool ExplodeMember(MemberInfo Member)
            {
            return Member.HasAttribute(typeof(CodeExplodeGenerics), true);
            }

        public Type[] GenericOutputTypes;

        public CodeExplode_ExplodeLogic(Type T)
            : base(T)
            {
            this.CodeRegionTitle = T.FullName;
            }
        public CodeExplode_ExplodeLogic(string CodeRegionTitle, string CodeFileName, string CodeNamespace, Type[] GenericOutputTypes = null) :
            base(CodeRegionTitle, CodeFileName, CodeNamespace)
            {
            this.GenericOutputTypes = GenericOutputTypes;
            }
        }
    }