using LCore.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
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
        /// The path relative to the root repository folder that this markdown file will be saved
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// The title of the markdown file
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Create a new GitHumMarkdown document without specifying a file title or location
        /// </summary>
        public GitHubMarkdown() {}

        /// <summary>
        /// Create a new GitHumMarkdown document specifying a file title and location
        /// </summary>
        public GitHubMarkdown([CanBeNull] string FilePath, [CanBeNull] string Title)
            {
            this.FilePath = (FilePath ?? "").Trim('/', '\\').ReplaceAll("\\", "/");
            this.Title = Title ?? "";
            }

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
            this.Line(Size == 1
                ? "======"
                : "------");
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
            DepthLine.Each(Line => this.OrderedList((Set<uint, string>) Line));
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
            DepthLine.Each(Line => this.UnorderedList((Set<uint, string>) Line));
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
            DepthLine.Each(Line => { this.Line($"{"  ".Times(Line.Obj1)}*{Line.Obj2}"); });
            }

        /// <summary>
        /// Add a strikethrough line
        /// 
        /// ~Line~
        /// 
        /// </summary>
        public void Strikethrough([CanBeNull] string Text)
            {
            if (!string.IsNullOrEmpty(Text))
                this.Line($"~~{Text}~~");
            }

        /// <summary>
        /// Add a highlight line
        /// 
        /// =Line=
        /// 
        /// </summary>
        public void Highlight([CanBeNull] string Text)
            {
            if (!string.IsNullOrEmpty(Text))
                this.Line($"=={Text}==");
            }

        /// <summary>
        /// Add a link, all arguments are optional
        /// 
        /// (Url)
        /// [Text]
        /// [Text](Url)
        /// [Text](Url)"Reference Text"
        /// 
        /// </summary>
        public void Link([CanBeNull] string Url = "", [CanBeNull] string Text = "", [CanBeNull] string ReferenceText = "")
            {
            if (!string.IsNullOrEmpty(Url))
                {
                Url = $"({Url})";
                if (!string.IsNullOrEmpty(ReferenceText))
                    ReferenceText = $"[{ReferenceText}]";
                }
            if (!string.IsNullOrEmpty(ReferenceText))
                ReferenceText = $" \"{ReferenceText}\"";

            this.Line($"[{Text}]{Url}{ReferenceText}");
            }

        /// <summary>
        /// Adds an image, optionally with Reference Text
        /// 
        /// !(Image Url)
        /// ![Reference Text](Image Url)
        /// 
        /// </summary>
        public void Image([CanBeNull] string Url, [CanBeNull] string ReferenceText = "")
            {
            if (!string.IsNullOrEmpty(ReferenceText))
                ReferenceText = $"[{ReferenceText}]";

            this.Line($"!{ReferenceText}({Url})");
            }

        /// <summary>
        /// Add a number of lines of code, optionally include a Language for 
        /// </summary>
        /// <param name="Lines"></param>
        /// <param name="Language"></param>
        public void Code([CanBeNull] string[] Lines = null, [CanBeNull] string Language = MarkdownGenerator.CSharpLanguage)
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
        /// Formats a glyphicon for display in a markdown document
        /// </summary>
        public string Glyph(GlyphIcon Glyph)
            {
            return $"<span class=\"glyphicon glyphicon-{Glyph.ToString().ToLower().Trim('_').ReplaceAll("_", "-")}\"></span>";
            }
        }
    }