using System;
using System.Reflection;

using LCore.Tools;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class CodeExplodeExtend : CodeExplode
        {
        public override string ExplodeCode(Lists<string, MemberInfo> t)
            {
            return L.Exploder.LogicMemberInfoToExtensionStrings(t, "", null);
            }

        public override bool ExplodeMember(MemberInfo Member)
            {
            return Member.HasAttribute(typeof(CodeExplodeExtensionMethod), true);
            }
        public CodeExplodeExtend(Type T)
            : base(T)
            {
            this.CodeRegionTitle = T.FullName;
            }
        public CodeExplodeExtend(string CodeRegionTitle, string CodeFileName, string CodeNamespace) :
            base(CodeRegionTitle, CodeFileName, CodeNamespace)
            {
            }
        }
    }