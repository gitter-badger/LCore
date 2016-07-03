using System;
using System.Reflection;
using LCore.Extensions;
using LCore.Tools;

namespace LCore.Dynamic
    {
    internal abstract class CodeExplode : Attribute, ISubClassPersistentAttribute
        {
        public const string ExplodeSuffix = "_Explode";
        public const string BackupSuffix = "_bak";

        public const string ExplodeFileType = ".cs";
        public abstract string ExplodeCode(Lists<string, MemberInfo> Members);

        public readonly string CodeFileName;
        public readonly string CodeNamespace;
        public string CodeRegionTitle;


        public abstract bool ExplodeMember(MemberInfo Member);

        public Type OutputType => Type.GetType($"{this.CodeNamespace}.{this.ClassName}");

        public virtual string ClassName => this.CodeFileName;

        protected CodeExplode(Type T)
            : this(T.FullName, T.Name, T.Namespace)
            {
            }

        protected CodeExplode(string CodeRegionTitle, string CodeFileName, string CodeNamespace)
            {
            this.CodeRegionTitle = CodeRegionTitle;
            this.CodeNamespace = CodeNamespace;

            this.CodeFileName = CodeFileName + ExplodeSuffix;
            }
        }
    }
