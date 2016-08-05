using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using LCore.Extensions;
using LCore.Tools;

namespace LCore.Dynamic
    {
    [ExcludeFromCodeCoverage]
    internal class CodeExplodeLogic : CodeExplode
        {
        /// <summary>
        /// One for methods with 0 parameters, 16 for methods up to 16 parameters.
        /// </summary>
        public const int ExplodeCount = 17;

        public override string ExplodeCode(Lists<string, MemberInfo> Members)
            {
            CodeExploder.DeclaredExtensionCache.Clear();

            return L.Exploder.LogicMemberInfoExplode(Members);
            }

        public override bool ExplodeMember(MemberInfo Member)
            {
            return Member.HasAttribute(typeof(CodeExplodeGenerics), true);
            }

        public Type[] GenericOutputTypes;

        public CodeExplodeLogic(Type T)
            : base(T)
            {
            this.CodeRegionTitle = T.FullName;
            }

        public CodeExplodeLogic(string CodeRegionTitle, string CodeFileName, string CodeNamespace, Type[] GenericOutputTypes = null) :
            base(CodeRegionTitle, CodeFileName, CodeNamespace)
            {
            this.GenericOutputTypes = GenericOutputTypes;
            }
        }
    }