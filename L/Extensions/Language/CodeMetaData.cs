using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    public class CodeMetaData
        {
        public const string TODO = nameof(TODO);

        public const string BUG = nameof(BUG);

        public Type Type { get; }

        [CanBeNull]
        public MemberInfo Member { get; }

        [CanBeNull]
        public ICodeComment Comments { get; }

        public uint? CodeLineNumber { get; }

        public uint? CodeLineCount { get; }

        public string[] CodeLines { get; }

        [CanBeNull]
        public string CodeFilePath { get; }

        public List<Attribute> Attributes { get; }

        public string[] CommentTODO { get; }

        public string[] CommentBUG { get; }

        public Dictionary<string, string[]> CommentTags { get; }

        public CodeMetaData([NotNull]MemberInfo Member, [CanBeNull]string[] TrackCommentTags = null)
            {
            this.Member = Member;
            this.Type = Member.DeclaringType;

            this.Comments = Member.GetComments();

            this.CodeLines = Member.FindSourceCode().Split("\r\n");

            this.CodeLineCount = Member.FindSourceCodeLineCount();
            this.CodeLineNumber = Member.FindSourceCodeLineNumber();

            this.CodeFilePath = Member.DeclaringType.FindClassFile();

            this.Attributes = Member.GetAttributes<Attribute>(IncludeBaseTypes: true);

            this.CommentTODO = this.ReadCommentTag(TODO);
            this.CommentBUG = this.ReadCommentTag(BUG);

            TrackCommentTags.Each(Tag => this.CommentTags.Add(Tag, this.ReadCommentTag(Tag)));
            }

        private string[] ReadCommentTag(string Tag)
            {
            var Out = new List<string>();
            this.CodeLines.Each(Line =>
                {
                    string TrimLine = Line.Trim();
                    if (TrimLine.StartsWith($"//{Tag}") || TrimLine.StartsWith($"// {Tag}"))
                        Out.Add(TrimLine.After(Tag));
                });

            return Out.Array();
            }
        }
    }