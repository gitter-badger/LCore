using System;
using System.Reflection;

using LCore.Tools;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class CodeExplode_ExtendLogic : CodeExplode
        {
        public override string ExplodeCode(Lists<string, MemberInfo> t)
            {
            return L.Exploder.LogicMemberInfo_ToExtensionStrings(t, "", null);
            }

        public override bool ExplodeMember(MemberInfo Member)
            {
            return Member.HasAttribute(typeof(CodeExplodeExtensionMethod), true);
            }
        public CodeExplode_ExtendLogic(Type T)
            : base(T)
            {
            this.CodeRegionTitle = T.FullName;
            }
        public CodeExplode_ExtendLogic(string CodeRegionTitle, string CodeFileName, string CodeNamespace) :
            base(CodeRegionTitle, CodeFileName, CodeNamespace)
            {
            }
        }
    }