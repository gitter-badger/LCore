using LCore.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverQueried.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming

namespace LCore.Tools
    {
    /// <summary>
    /// Helper class for generating GitHub markdown documents.
    /// </summary>
    public class GitHubMarkdown
        {
        /// <summary>
        /// List of all Markdown Lines added.
        /// </summary>
        protected List<string> MarkdownLines { get; } = new List<string>();


        /// <summary>
        /// Add a blank line:
        /// </summary>
        public void BlankLine()
            {
            this.Line("");
            }

        /// <summary>
        /// Add a horizontal rule:
        /// 
        /// ---
        /// 
        /// 
        /// </summary>
        public void HorizontalRule()
            {
            this.Line("---");
            }

        /// <summary>
        /// Add a header line:
        /// 
        /// # Header
        /// ## Header
        /// ### Header
        /// #### Header
        /// ##### Header
        /// ###### Header
        /// 
        /// </summary>
        public void Header(string Line, int Size = 1)
            {
            if (Size < 1)
                Size = 1;
            if (Size > 6)
                Size = 6;

            this.Line($"{"#".Times(Size)}{Line}");
            }

        /// <summary>
        /// Add a header underlined:
        /// 
        /// Line
        /// ======
        /// 
        /// Line 
        /// ------
        /// </summary>
        public void HeaderUnderline(string Line, int Size = 1)
            {
            if (Size < 1)
                Size = 1;
            if (Size > 2)
                Size = 2;

            this.Line($"{Line}");
            this.Line(Size == 1 ? "======" : "------");
            }

        /// <summary>
        /// Add an ordered list
        /// 
        /// 1. Line
        /// 2. Line
        /// 3. Line
        /// 
        /// </summary>
        public void OrderedList([CanBeNull] params string[] Lines)
            {
            Lines.Each((i, Line) => this.Line($"{i + 1}. {Line}"));
            }

        /// <summary>
        /// Add an ordered list with indentation
        /// 
        /// 1. Item
        /// 2. Item
        ///     1. Subitem
        ///     2. Subitem
        ///     3. Subitem
        /// 3. Item
        /// 
        /// </summary>
        public void OrderedList([CanBeNull] params Tuple<uint, string>[] DepthLine)
            {
            DepthLine.Each(Line => this.OrderedList((Set<uint, string>)Line));
            }

        /// <summary>
        /// Add an ordered list with indentation
        /// 
        /// 1. Item
        /// 2. Item
        ///     1. Subitem
        ///     2. Subitem
        ///     3. Subitem
        /// 3. Item
        /// 
        /// </summary>
        public void OrderedList([CanBeNull] params Set<uint, string>[] DepthLine)
            {
            uint CurrentNumber = 0;
            uint? LastLevel = null;

            DepthLine.Each(Line =>
                {
                    if (LastLevel == null || Line.Obj1 != LastLevel)
                        CurrentNumber = 1;

                    this.Line($"{"  ".Times(Line.Obj1)}{CurrentNumber}{Line.Obj2}");

                    LastLevel = Line.Obj1;
                    CurrentNumber++;
                });
            }

        /// <summary>
        /// Add an unordered list
        /// 
        /// - Line
        /// - Line
        /// - Line
        /// 
        /// </summary>
        public void UnorderedList([CanBeNull] params string[] Lines)
            {
            Lines.Each(Line => this.Line($"- {Line}"));
            }

        /// <summary>
        /// Add an unordered list with indentation
        /// 
        /// - Item
        /// - Item
        ///     - Subitem
        ///     - Subitem
        ///     - Subitem
        /// - Item
        /// 
        /// </summary>
        public void UnorderedList([CanBeNull] params Tuple<uint, string>[] DepthLine)
            {
            DepthLine.Each(Line => this.UnorderedList((Set<uint, string>)Line));
            }

        /// <summary>
        /// Add an unordered list with indentation
        /// 
        /// - Item
        /// - Item
        ///     - Subitem
        ///     - Subitem
        ///     - Subitem
        /// - Item
        /// 
        /// </summary>
        public void UnorderedList([CanBeNull] params Set<uint, string>[] DepthLine)
            {
            DepthLine.Each(Line =>
                {
                    this.Line($"{"  ".Times(Line.Obj1)}*{Line.Obj2}");
                });
            }

        /// <summary>
        /// Add a number of lines of code, optionally include a Language for 
        /// </summary>
        /// <param name="Lines"></param>
        /// <param name="Language"></param>
        public void Code([CanBeNull] string[] Lines = null, [CanBeNull] string Language = "")
            {
            this.Line($"```{Language}");
            Lines.Each(this.Line);
            this.Line("```");
            }

        /// <summary>
        /// Add a table of data.
        /// By default, the first row will be used as the header row, and separator will be added
        /// 
        /// Header |  Header | Header
        /// -------------------------
        /// Data | Data | Data
        /// Data | Data | Data
        /// 
        /// //////////////////////////////////////////
        /// 
        /// Data | Data | Data
        /// Data | Data | Data
        /// Data | Data | Data
        /// 
        /// </summary>
        public void Table([CanBeNull] string[,] Rows, bool IncludeHeader = true)
            {
            if (Rows == null)
                return;

            int ColumnCount = Rows.GetLength(dimension: 0);
            int RowCount = Rows.GetLength(dimension: 1);

            var Table = new List<string>();
            var Divider = new List<string>();

            for (int i = 0; i < RowCount; i++)
                {
                var Cells = new List<string>();
                for (int j = 0; j < ColumnCount; j++)
                    {
                    string Cell = Rows[j, i];
                    Cells.Add(Cell);
                    if (IncludeHeader && i == 0)
                        Divider.Add(" --- ");
                    }

                Table.Add(Cells.JoinLines(" | "));
                if (IncludeHeader && i == 0)
                    Table.Add(Divider.JoinLines(" | "));
                }

            Table.Each(this.Line);
            }

        /// <summary>
        /// Add a table of data.
        /// By default, the first row will be used as the header row, and separator will be added
        /// 
        /// Header |  Header | Header
        /// -------------------------
        /// Data | Data | Data
        /// Data | Data | Data
        /// 
        /// //////////////////////////////////////////
        /// 
        /// Data | Data | Data
        /// Data | Data | Data
        /// Data | Data | Data
        /// 
        /// </summary>
        public void Table([CanBeNull] IEnumerable<IEnumerable<string>> Rows, bool IncludeHeader = true)
            {
            if (Rows == null)
                return;

            var Table = new List<string>();
            var Divider = new List<string>();

            Rows.Each((i, Row) =>
            {
                var Cells = new List<string>();

                Row.Each((j, Column) =>
                {
                    Cells.Add(Column);
                    if (IncludeHeader && i == 0)
                        Divider.Add(" --- ");
                });
                Table.Add(Cells.JoinLines(" | "));
                if (IncludeHeader && i == 0)
                    Table.Add(Divider.JoinLines(" | "));
            });

            Table.Each(this.Line);
            }

        /// <summary>
        /// Adds a blockquoted series of <paramref name="Lines"/>
        /// </summary>
        public void BlockQuote([CanBeNull] params string[] Lines)
            {
            Lines.Each(Line => this.Line($"> {Line}"));
            }

        /// <summary>
        /// Add a number of <paramref name="Lines"/>
        /// </summary>
        public void Lines([CanBeNull] params string[] Lines)
            {
            Lines?.Each(this.Line);
            }

        /// <summary>
        /// Add a single <paramref name="Line"/>
        /// </summary>
        public void Line([CanBeNull] string Line)
            {
            if (Line != null)
                this.MarkdownLines.Add(Line);
            }



        /// <summary>
        /// Returns strikethrough line
        /// 
        /// ~Line~
        /// 
        /// </summary>
        public string Strikethrough([CanBeNull] string Text)
            {
            return !string.IsNullOrEmpty(Text)
                ? $"~~{Text}~~"
                : "";
            }

        /// <summary>
        /// Returns highlighted test
        /// 
        /// =Line=
        /// 
        /// </summary>
        public string Highlight([CanBeNull] string Text)
            {
            return !string.IsNullOrEmpty(Text)
                ? $"=={Text}=="
                : "";
            }

        /// <summary>
        /// Returns a link, all arguments are optional
        /// 
        /// (Url)
        /// [Text]
        /// [Text](Url)
        /// [Text](Url)"Reference Text"
        /// 
        /// </summary>
        public string Link([CanBeNull] string Url = "", [CanBeNull] string Text = "", [CanBeNull] string ReferenceText = "")
            {
            if (!string.IsNullOrEmpty(Url))
                {
                Url = $"({Url})";
                if (!string.IsNullOrEmpty(ReferenceText))
                    ReferenceText = $"[{ReferenceText}]";
                }
            if (!string.IsNullOrEmpty(ReferenceText))
                ReferenceText = $" \"{ReferenceText}\"";

            return $"[{Text}]{Url}{ReferenceText}";
            }

        /// <summary>
        /// Returns an image link, optionally with Reference Text
        /// 
        /// !(Image Url)
        /// ![Reference Text](Image Url)
        /// 
        /// </summary>
        public string Image([CanBeNull] string Url, [CanBeNull] string ReferenceText = "")
            {
            if (!string.IsNullOrEmpty(ReferenceText))
                ReferenceText = $"[{ReferenceText}]";

            return $"!{ReferenceText}({Url})";
            }

        /// <summary>
        /// Returns a string formatted as inline code
        /// </summary>
        public string InlineCode([CanBeNull] string Code = "")
            {
            return Code == null
                ? ""
                : $"`{Code}`";
            }

        /// <summary>
        /// Returns a string formatted in italics
        /// 
        /// *Text*
        /// 
        /// </summary>
        public string Italic([CanBeNull] string Text = "")
            {
            return Text == null
                ? ""
                : $"*{Text}*";
            }

        /// <summary>
        /// Returns a string formatted as bold
        /// 
        /// **Text**
        /// 
        /// </summary>
        public string Bold([CanBeNull] string Text = "")
            {
            return Text == null
                ? ""
                : $"**{Text}**";
            }
        }

    internal class MarkdownGenerator
        {
        protected Dictionary<Assembly, GitHubMarkdown> AssemblyMarkdown { get; } = new Dictionary<Assembly, GitHubMarkdown>();
        protected Dictionary<Type, GitHubMarkdown> TypeMarkdown { get; } = new Dictionary<Type, GitHubMarkdown>();
        protected Dictionary<MemberInfo, GitHubMarkdown> MemberMarkdown { get; } = new Dictionary<MemberInfo, GitHubMarkdown>();

        protected virtual GitHubMarkdown GenerateMarkdown(Assembly Assembly)
            {
            // TODO generate Assembly markdown

            return null;
            }

        protected virtual GitHubMarkdown GenerateMarkdown(Type Type)
            {
            // TODO generate Type markdown

            return null;
            }

        protected virtual GitHubMarkdown GenerateMarkdown(MemberInfo Member)
            {
            var MD = new GitHubMarkdown();

            MD.Header($"{Member.DeclaringType?.Name}", Size: 3);
            MD.Header(Member.Name);

            string PathToRoot = "../../..";

            if (Member is MethodInfo)
                {
                var Method = (MethodInfo)Member;

                var Comments = Method.GetComments();

                string Static = Method.IsStatic
                    ? "Static "
                    : "Instance";

                string ReturnType = Method.ReturnType == typeof(void)
                    ? "void"
                    : Method.ReturnType.FullyQualifiedName();

                string Parameters = Method.GetParameters().Convert(Param =>
                    $"{Param.ParameterType.GetGenericName()} {Param.Name}").Combine(", ");

                MD.Header($"{Static}Method", Size: 4);

                MD.Header($"public static {ReturnType} {Member.Name}({Parameters});", Size: 6);

                MD.Header("Summary", Size: 6);
                MD.Line(Comments?.Summary);

                if (Method.GetParameters().Length > 0)
                    {
                    MD.Header("Parameters", Size: 6);

                    var Table = new List<string[]>
                        {
                        new[] {"Parameter", "Optional", "Type", "Description"}
                        };

                    Method.GetParameters().Each((k, Param) =>
                        {
                            Table.Add(new[]
                                {
                                Param.Name,
                                Param.IsOptional ? "Yes" : "No",
                                Param.ParameterType.GetGenericName(),
                                Comments?.Parameters[k].Obj2
                                });
                        });

                    MD.Table(Table);
                    }

                MD.Header("Returns", Size: 4);

                MD.Header(Method.ReturnType == typeof(void)
                    ? "void"
                    : Method.ReturnType.GetGenericName(), Size: 6);

                MD.Line(Comments?.Returns);
                }


            return MD;
            }

        protected virtual string GeneratedMarkdownRoot => "/GeneratedMarkdown";

        protected virtual string AssemblyMarkdownPath(Assembly Assembly) =>
            $"{this.GeneratedMarkdownRoot}/{Assembly.GetName().Name}.md";

        protected virtual string AssemblyMarkdownPath(Type Type) =>
            $"{this.GeneratedMarkdownRoot}/{Type.GetAssembly()?.GetName().Name}/{Type.Name}.md";

        protected virtual string AssemblyMarkdownPath(MemberInfo Member) =>
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