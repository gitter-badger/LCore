using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LCore.Extensions;
using LCore.LDoc.Markdown;
using LCore.Tools;

namespace LCore.Tests
    {
    /// <summary>
    /// Generates markdown for the LUnit project
    /// </summary>
    public class LCoreMarkdownGenerator : SolutionMarkdownGenerator_L
        {
        /// <summary>
        /// Override this member to specify the assemblies to generae documentation.
        /// </summary>
        public override Assembly[] DocumentAssemblies => new[] { Assembly.GetAssembly(typeof(L)) };

        public override void Home_Intro(GeneratedDocument MD)
            {
            }

        public override void HowToInstall(GeneratedDocument MD)
            {
            MD.Line($"Add {nameof(LCore)} as a nuget package:");
            MD.Code(new[] { $"Install-Package {nameof(LCore)}" });
            }

        public override List<ProjectInfo> Home_RelatedProjects
            => base.Home_RelatedProjects.Select(Project => Project.Name != nameof(LCore));

        public override string RootUrl => LCore.LUnit.LUnit.Urls.GitHubRepository_LCore;

        /// <summary>
        /// Override this value to display a large image on top ofthe main document
        /// </summary>
        public override string BannerImage_Large(GeneratedDocument MD) =>
            MD.GetRelativePath($"{typeof(L).GetAssembly().GetRootPath()}\\Content\\{nameof(LCore)}-banner-large.png");

        /// <summary>
        /// Override this value to display a small banner image on top of sub-documents
        /// </summary>
        public override string BannerImage_Small(GeneratedDocument MD) =>
            MD.GetRelativePath($"{typeof(L).GetAssembly().GetRootPath()}\\Content\\{nameof(LCore)}-banner-small.png");

        /// <summary>
        /// Override this value to display a large image in the upper right corner of the main document
        /// </summary>
        public override string LogoImage_Large(GeneratedDocument MD) =>
            MD.GetRelativePath($"{typeof(L).GetAssembly().GetRootPath()}\\Content\\{nameof(LCore)}-logo-small.png");

        /// <summary>
        /// Override this value to display a small image in the upper right corner of sub-documents
        /// </summary>
        public override string LogoImage_Small(GeneratedDocument MD) =>
            MD.GetRelativePath($"{typeof(L).GetAssembly().GetRootPath()}\\Content\\{nameof(LCore)}-logo-small.png");

        public override bool RequireDirectLinksToAllForeignTypes => true;

        public override Dictionary<Type, string> CustomTypeLinks => new Dictionary<Type, string>
            {
            [typeof(Set<,>)] = "", // TODO link once document is up
            [typeof(ExceptionList)] = "", // TODO fix, this should be resolving internally

            [typeof(Schedule)] = ""
            };
        }
    }