using System;
using System.Collections.Generic;
using System.Reflection;

namespace LCore.Dynamic
    {
    public abstract class CodeExplode : Attribute
        {
        public const String ExplodeSuffix = "_Explode";
        public const String BackupSuffix = "_bak";
        
        public const String ExplodeFileType = ".cs";
        public abstract String ExplodeCode(Lists<String, MemberInfo> Members);

        public String CodeFileName;
        public String CodeNamespace;
        public String CodeRegionTitle;


        public abstract Boolean ExplodeMember(MemberInfo Member);

        public Type OutputType
            {
            get
                {
                return Type.GetType(CodeNamespace + "." + ClassName); // L.SafeGetType
                }
            }
        public virtual String ClassName
            {
            get
                {
                return CodeFileName;
                }
            }

        public CodeExplode(Type T)
            : this(T.FullName, T.Name, T.Namespace)
            {
            }
        public CodeExplode(String CodeRegionTitle, String CodeFileName, String CodeNamespace)
            {
            this.CodeRegionTitle = CodeRegionTitle;
            this.CodeNamespace = CodeNamespace;

            this.CodeFileName = CodeFileName + ExplodeSuffix;
            }
        }
    }
