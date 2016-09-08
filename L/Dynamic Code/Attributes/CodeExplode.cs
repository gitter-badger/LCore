using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using LCore.Extensions;
using LCore.Tools;

namespace LCore.Dynamic
    {
    [ExcludeFromCodeCoverage]
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

        public Type OutputType
            {
            get
                {
                try
                    {
                    return Type.GetType($"{this.CodeNamespace}.{this.ClassName}");
                    }
                catch (Exception)
                    {
                    return null;
                    }
                }
            }

        public string ClassName => this.CodeFileName;

        protected CodeExplode(Type T)
            // ReSharper disable once AssignNullToNotNullAttribute
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