using Microsoft.AspNet.Scaffolding;
using Microsoft.AspNet.Scaffolding.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Singularity_Scaffolds.UI
    {
    /// <summary>
    /// View model for code types so that it can be displayed on the UI.
    /// </summary>
    public class CustomViewModel
        {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The code generation context</param>
        public CustomViewModel(CodeGenerationContext context)
            {
            this.Context = context;
            }

        /// <summary>
        /// This gets all the Model types from the active project.
        /// </summary>
        public IEnumerable<ModelType> ModelTypes
            {
            get
                {
                ICodeTypeService codeTypeService = (ICodeTypeService)this.Context
                    .ServiceProvider.GetService(typeof(ICodeTypeService));

                return codeTypeService
                    .GetAllCodeTypes(this.Context.ActiveProject)
                    .Where(codeType => codeType.IsValidWebProjectEntityType())
                    .Select(codeType => new ModelType(codeType));
                }
            }

        public ModelType SelectedModelType { get; set; }

        public CodeGenerationContext Context { get; }
        }
    }
