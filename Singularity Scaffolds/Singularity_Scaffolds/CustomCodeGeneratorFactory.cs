using Microsoft.AspNet.Scaffolding;
using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Singularity_Scaffolds
    {
    [Export(typeof(CodeGeneratorFactory))]
    public class CustomCodeGeneratorFactory : CodeGeneratorFactory
        {
        /// <summary>
        ///  Information about the code generator goes here.
        /// </summary>
        private static readonly CodeGeneratorInformation _info = new CodeGeneratorInformation(
            "Custom Scaffolder",
            "This is a custom scaffolder.",
            "Author Name",
            new Version(1, 0, 0, 0),
            typeof(CustomCodeGenerator).Name,
            ToImageSource(Resources.__TemplateIcon),
            new[] { "Controller", "View", "Area" },
            new[] { Categories.Common, Categories.MvcController, Categories.Other });

        public CustomCodeGeneratorFactory()
            : base(_info)
            {
            }
        /// <summary>
        /// This method creates the code generator instance.
        /// </summary>
        /// <param name="context">The context has details on current active project, project item selected, Nuget packages that are applicable and service provider.</param>
        /// <returns>Instance of CodeGenerator.</returns>
        public override ICodeGenerator CreateInstance(CodeGenerationContext context)
            {
            return new CustomCodeGenerator(context, this.Information);
            }

        /// <summary>
        /// Provides a way to check if the custom scaffolder is valid under this context
        /// </summary>
        /// <param name="codeGenerationContext">The code generation context</param>
        /// <returns>True if valid, False otherwise</returns>
        public override bool IsSupported(CodeGenerationContext codeGenerationContext)
            {
            return codeGenerationContext.ActiveProject.CodeModel.Language == EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp;
            }

        /// <summary>
        /// Helper method to convert Icon to Imagesource.
        /// </summary>
        /// <param name="icon">Icon</param>
        /// <returns>Imagesource</returns>
        public static ImageSource ToImageSource(Icon icon)
            {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
            }
        }
    }
