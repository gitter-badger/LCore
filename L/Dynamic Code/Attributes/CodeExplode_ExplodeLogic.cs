using System;
using System.Collections.Generic;
using System.Reflection;

namespace LCore.Dynamic
    {
    public class CodeExplode_ExplodeLogic : CodeExplode
        {
        // One for methods with 0 parameters, 16 for methods up to 16 parameters.
        public const int ExplodeCount = 17;

        public override String ExplodeCode(Lists<String, MemberInfo> t)
            {
            CodeExploder.DeclaredExtensionCache.Clear();
            return L.LogicMemberInfo_Explode(t);
            }
        public override bool ExplodeMember(MemberInfo Member)
            {
            return Member.MemberHasAttribute(typeof(CodeExplodeGenerics), true);
            }

        public Type[] GenericOutputTypes;

        public CodeExplode_ExplodeLogic(Type T)
            : base(T)
            {
            this.CodeRegionTitle = T.FullName;
            }
        public CodeExplode_ExplodeLogic(String CodeRegionTitle, String CodeFileName, String CodeNamespace) :
            this(CodeRegionTitle, CodeFileName, CodeNamespace, null)
            {
            }
        public CodeExplode_ExplodeLogic(String CodeRegionTitle, String CodeFileName, String CodeNamespace, Type[] GenericOutputTypes) :
            base(CodeRegionTitle, CodeFileName, CodeNamespace)
            {
            this.GenericOutputTypes = GenericOutputTypes;
            }
        }
    }