using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using LCore.Extensions;

namespace LCore.Tools
    {
    internal class MarkdownGenerator
        {
        public const string CSharpLanguage = "cs";


        protected Dictionary<Assembly, GitHubMarkdown> AssemblyMarkdown { get; } = new Dictionary<Assembly, GitHubMarkdown>();
        protected Dictionary<Type, GitHubMarkdown> TypeMarkdown { get; } = new Dictionary<Type, GitHubMarkdown>();
        protected Dictionary<MemberInfo, GitHubMarkdown> MemberMarkdown { get; } = new Dictionary<MemberInfo, GitHubMarkdown>();


        protected virtual GitHubMarkdown GenerateMarkdown(Assembly Assembly)
            {
            return null;
            }

        protected virtual GitHubMarkdown GenerateMarkdown(Type Type)
            {
            return null;
            }

        protected virtual GitHubMarkdown GenerateMarkdown(MemberInfo Member)
            {
            var MD = new GitHubMarkdown(this.MarkdownPath_Member(Member), Member.Name);

            MD.Header($"{Member.DeclaringType?.Name}", Size: 3);
            MD.Header(Member.Name);

            if (Member is MethodInfo)
                {
                var Method = (MethodInfo)Member;

                var Comments = Method.GetComments();

                string Static = Method.IsStatic
                    ? "Static "
                    : "Instance";

                string StaticLower = Method.IsStatic
                    ? " static"
                    : "";

                // TODO: Add return type link
                string ReturnType = Method.ReturnType == typeof(void)
                    ? "void"
                    : Method.ReturnType.FullyQualifiedName();


                // TODO: Add parameter type link
                string Parameters = Method.GetParameters().Convert(Param =>
                    $"{Param.ParameterType.GetGenericName()} {Param.Name}").Combine(", ");

                MD.Header($"{Static}Method", Size: 4);

                MD.Header($"public{StaticLower} {ReturnType} {Member.Name}({Parameters});", Size: 6);

                MD.Header("Summary", Size: 6);
                MD.Line(Comments?.Summary);

                if (Method.GetParameters().Length > 0)
                    {
                    MD.Header("Parameters", Size: 6);

                    var Table = new List<string[]>
                        {
                        new[] {"Parameter", "Optional", "Type", "Description"}
                        };

                    // TODO: Add parameter type link
                    Method.GetParameters().Each((ParamIndex, Param) =>
                        {
                            Table.Add(new[]
                                {
                            Param.Name,
                            Param.IsOptional
                                ? "Yes"
                                : "No",
                            Param.ParameterType.GetGenericName(),
                            Comments?.Parameters[ParamIndex].Obj2
                            });
                        });

                    MD.Table(Table);
                    }

                MD.Header("Returns", Size: 4);

                // TODO: Add return type link
                MD.Header(Method.ReturnType == typeof(void)
                    ? "void"
                    : Method.ReturnType.GetGenericName(), Size: 6);

                MD.Line(Comments?.Returns);

                if (Comments?.Examples.Length > 0)
                    {
                    MD.Header("Examples", Size: 4);
                    Comments.Examples.Each(Example => MD.Code(new[] { Example }));
                    }

                // TODO: Add source link
                // TODO: Add test coverage link
                // TODO: Add exception details
                // TODO: Add permission details
                // TODO: Add root link
                // TODO: Add [this markdown was auto-generated by LCore]
                }

            return MD;
            }


        protected virtual GitHubMarkdown GenerateRootMarkdown()
            {
            return null;
            }

        protected virtual GitHubMarkdown GenerateTableOfContentsMarkdown()
            {
            return null;
            }

        protected virtual string GeneratedMarkdownRoot => "/GeneratedMarkdown";


        protected virtual string MarkdownPath_Root => "readme.md";
        protected virtual string MarkdownPath_TableOfContents => "TableOfContents.md";

        protected virtual string MarkdownPath_Assembly(Assembly Assembly) =>
            $"{this.GeneratedMarkdownRoot}/{Assembly.GetName().Name}.md";

        protected virtual string MarkdownPath_Type(Type Type) =>
            $"{this.GeneratedMarkdownRoot}/{Type.GetAssembly()?.GetName().Name}/{Type.Name}.md";

        protected virtual string MarkdownPath_Member(MemberInfo Member) =>
            $"{this.GeneratedMarkdownRoot}/{Member.DeclaringType.GetAssembly()?.GetName().Name}/{Member.DeclaringType?.Name}/{Member.Name}.md";


        protected virtual bool IncludeType(Type Type) =>
            !Type.HasAttribute<ExcludeFromCodeCoverageAttribute>(IncludeBaseClasses: true) &&
            !Type.HasAttribute<IExcludeFromMarkdownAttribute>();

        protected virtual bool IncludeMember(MemberInfo Member) =>
            !Member.HasAttribute<ExcludeFromCodeCoverageAttribute>(IncludeBaseClasses: true) &&
            !Member.HasAttribute<IExcludeFromMarkdownAttribute>();


        public void Load(Assembly Assembly)
            {
            this.AssemblyMarkdown.Add(Assembly, this.GenerateMarkdown(Assembly));

            Assembly.GetExportedTypes().Select(this.IncludeType).Each(this.Load);
            }

        public void Load(Type Type)
            {
            this.TypeMarkdown.Add(Type, this.GenerateMarkdown(Type));

            Type.GetMembers().Select(this.IncludeMember).Each(this.Load);
            }

        public void Load(MemberInfo Member)
            {
            this.MemberMarkdown.Add(Member, this.GenerateMarkdown(Member));
            }
        }
    }