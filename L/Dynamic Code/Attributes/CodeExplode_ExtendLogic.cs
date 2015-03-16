using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace LCore.Dynamic
    {
    public class CodeExplode_ExtendLogic : CodeExplode
        {
        public override String ExplodeCode(Lists<String, MemberInfo> t)
            {
            return L.LogicMemberInfo_ToExtensionStrings(t, "", null);
            }

        public override bool ExplodeMember(MemberInfo Member)
            {
            return Member.MemberHasAttribute(typeof(CodeExplodeExtensionMethod), true);
            }
        public CodeExplode_ExtendLogic(Type T)
            : base(T)
            {
            this.CodeRegionTitle = T.FullName;
            }
        public CodeExplode_ExtendLogic(String CodeRegionTitle, String CodeFileName, String CodeNamespace) :
            base(CodeRegionTitle, CodeFileName, CodeNamespace)
            {
            }
        }
    }