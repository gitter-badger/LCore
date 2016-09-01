using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Interfaces;
// ReSharper disable InconsistentNaming

namespace LCore.Extensions
    {
    /// <summary>
    /// Gathers information about a piece of code, based on a <see cref="MemberInfo"/>
    /// </summary>
    public class CodeMetaData
        {
        /// <summary>
        /// String that tracks to-do comments
        /// </summary>
        public const string TODO = nameof(TODO);

        /// <summary>
        /// Tracks bugs using this string
        /// </summary>
        public const string BUG = nameof(BUG);

        /// <summary>
        /// Tracks unimplemented members using this string
        /// </summary>
        public const string NewNotImplemented = "throw new NotImplementedException";

        /// <summary>
        /// The declaring type of the target member
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// The source member
        /// </summary>
        public MemberInfo Member { get; }

        /// <summary>
        /// Details about the declaration of the member
        /// </summary>
        public MemberDetails Details { get; }

        /// <summary>
        /// Any comments, if declared, on the target  member
        /// </summary>
        [CanBeNull]
        public ICodeComment Comments { get; }

        /// <summary>
        /// The starting line number of the source member.
        /// Line number is 1-based, not 0-based.
        /// </summary>
        public uint? CodeLineNumber { get; }

        /// <summary>
        /// The number of non-empty code lines for the target member
        /// </summary>
        public uint? CodeLineCount { get; }

        /// <summary>
        /// An array of all code lines for the target member
        /// </summary>
        public string[] CodeLines { get; }

        /// <summary>
        /// The full file path where the target member is declared
        /// </summary>
        [CanBeNull]
        public string CodeFilePath { get; }

        /// <summary>
        /// All attributes defined on the target member
        /// </summary>
        public List<Attribute> Attributes { get; }

        /// <summary>
        /// All todo comments declared within the target member's code
        /// </summary>
        public CodeLineInfo[] CommentTODO { get; }

        /// <summary>
        /// All bugs declared within the target member's code comments
        /// </summary>
        public CodeLineInfo[] CommentBUG { get; }

        /// <summary>
        /// All unimplemented sections within the target member's code comments
        /// </summary>
        public CodeLineInfo[] NotImplemented { get; }

        /// <summary>
        /// All custom comments that are being tracked
        /// </summary>
        public Dictionary<string, List<CodeLineInfo>> CommentTags { get; } = new Dictionary<string, List<CodeLineInfo>>();

        /// <summary>
        /// Create a new CodeMetaData.
        /// 
        /// Optionally, include <paramref name="TrackCommentTags"/> to track additional comments.
        /// </summary>
        public CodeMetaData([NotNull]MemberInfo Member, [CanBeNull]string[] TrackCommentTags = null)
            {
            this.Member = Member;

            this.Details = Member.GetMemberDetails();

            this.Type = Member.DeclaringType;

            this.Comments = Member.GetComments();

            this.CodeLines = Member.FindSourceCode().Split("\r\n");

            this.CodeLineCount = Member.FindSourceCodeLineCount();
            this.CodeLineNumber = Member.FindSourceCodeLineNumber();

            this.CodeFilePath = Member.DeclaringType.FindClassFile();

            this.Attributes = Member.GetAttributes<Attribute>(IncludeBaseTypes: true);

            this.CommentTODO = this.ReadCommentTag(TODO).Array();
            this.CommentBUG = this.ReadCommentTag(BUG).Array();

            this.NotImplemented = this.ReadCommentTag(NewNotImplemented).Array();

            TrackCommentTags.Each(Tag => this.CommentTags.Add(Tag, this.ReadCommentTag(Tag)));
            }

        private List<CodeLineInfo> ReadCommentTag(string Tag)
            {
            var Out = new List<CodeLineInfo>();
            this.CodeLines.Each((i, Line) =>
                {
                    string TrimLine = Line.Trim();
                    if (TrimLine.StartsWith($"//{Tag}") || TrimLine.StartsWith($"// {Tag}"))
                        Out.Add(new CodeLineInfo()
                            {
                            LineText = Line,
                            LineNumber = (uint)(i + 1), // Line numbers are 1-based
                            FilePath = this.CodeFilePath
                            });

                });

            return Out;
            }
        }
    }