using System;
using System.Globalization;
using EnvDTE;

namespace Singularity_Scaffolds.UI
    {
    /// <summary>
    /// Wrapper for CodeType so we can use it in the UI.
    /// </summary>
    public class ModelType
        {
        public ModelType(CodeType codeType)
            {
            if (codeType == null)
                {
                throw new ArgumentNullException(nameof(codeType));
                }

            this.CodeType = codeType;
            this.TypeName = codeType.FullName;
            this.ShortTypeName = codeType.Name;
            this.DisplayName = string.IsNullOrWhiteSpace(codeType.Namespace?.FullName)
                            ? codeType.Name
                            : string.Format(CultureInfo.InvariantCulture, "{0} ({1})", codeType.Name, codeType.Namespace.FullName);
            }

        public CodeType CodeType { get; set; }

        public string DisplayName { get; set; }

        public string TypeName { get; set; }

        public string ShortTypeName { get; set; }
        }
    }
