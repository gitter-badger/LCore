using LCore.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
// ReSharper disable UnusedMember.Global

namespace LCore.Tools
    {
    internal class GitHubMarkdown
        {
        public GitHubMarkdown()
            {

            }

        public void BlankLine()
            {
            this.AddLine();
            }


        public void HorizontalRule()
            {
            this.AddLine("---");
            }

        public void Header(string Line, int Size = 1)
            {
            if (Size < 1)
                Size = 1;
            if (Size > 6)
                Size = 6;

            this.AddLine($"{"#".Times(Size)}{Line}");
            }

        public void HeaderUnderline(string Line, int Size = 1)
            {
            if (Size < 1)
                Size = 1;
            if (Size > 2)
                Size = 2;

            this.AddLine($"{Line}");
            this.AddLine(Size == 1 ? "======" : "------");
            }

        public void OrderedList([CanBeNull]params string[] Lines)
            {
            Lines.Each((i, Line) => this.AddLine($"{i + 1}. {Line}"));
            }

        public void OrderedList([CanBeNull]params Tuple<uint, string>[] DepthLine)
            {
            DepthLine.Each(Line => this.OrderedList((Set<uint, string>)Line));
            }
        public void OrderedList([CanBeNull]params Set<uint, string>[] DepthLine)
            {
            uint CurrentNumber = 0;
            uint? LastLevel = null;

            DepthLine.Each(Line =>
                {
                    if (LastLevel == null || Line.Obj1 != LastLevel)
                        CurrentNumber = 1;

                    this.AddLine($"{"  ".Times(Line.Obj1)}{CurrentNumber}{Line.Obj2}");

                    LastLevel = Line.Obj1;
                    CurrentNumber++;
                });
            }


        public void UnorderedList([CanBeNull]params string[] Lines)
            {
            Lines.Each(Line => this.AddLine($"- {Line}"));
            }

        public void UnorderedList([CanBeNull]params Tuple<uint, string>[] DepthLine)
            {
            DepthLine.Each(Line => this.UnorderedList((Set<uint, string>)Line));
            }
        public void UnorderedList([CanBeNull]params Set<uint, string>[] DepthLine)
            {
            DepthLine.Each(Line =>
            {
                this.AddLine($"{"  ".Times(Line.Obj1)}*{Line.Obj2}");
            });
            }



        public void Link([CanBeNull]string Text, [CanBeNull]string Url = "", [CanBeNull]string ReferenceText = "")
            {
            if (!string.IsNullOrEmpty(Url))
                {
                Url = $"({Url})";
                if (!string.IsNullOrEmpty(ReferenceText))
                    ReferenceText = $"[{ReferenceText}]";
                }
            if (!string.IsNullOrEmpty(ReferenceText))
                ReferenceText = $" \"{ReferenceText}\"";

            this.AddLine($"[{Text}]{Url}{ReferenceText}");
            }

        public void Image([CanBeNull] string Url, [CanBeNull] string ReferenceText = "")
            {
            if (!string.IsNullOrEmpty(ReferenceText))
                ReferenceText = $"[{ReferenceText}]";

            this.AddLine($"!{ReferenceText}({Url})");
            }

        public void Code([CanBeNull]string Language = "", [CanBeNull]IEnumerable<string> Lines = null)
            {
            this.AddLine($"```{Language}");
            Lines.Each(this.AddLine);
            this.AddLine("```");
            }

        public void Table([CanBeNull] string[,] Rows, bool IncludeHeader)
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

            Table.Each(this.AddLine);
            }

        public void BlockQuote([CanBeNull] params string[] Lines)
            {
            Lines.Each(Line => this.AddLine($"> {Line}"));
            }

        public void Lines([CanBeNull] params string[] AddLines)
            {
            AddLines?.Each(this.AddLine);
            }


        private void AddLine([CanBeNull]string Line = "")
            {
            if (Line != null)
                this.AllLines.Add(Line);
            }

        protected List<string> AllLines { get; } = new List<string>();
        }
    }