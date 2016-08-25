using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    public class CodeMetaData
        {
        public MemberInfo Member { get; set; }

        public ICodeComment Comments { get; set; }

        public uint? CodeLineNumber { get; set; }

        public uint? CodeLineCount { get; set; }

        public string[] CodeLines { get; set; }

        public string CodeFilePath { get; set; }

        public List<Attribute> Attributes { get; set; }

        public CodeMetaData(MemberInfo Member)
            {
            this.Member = Member;

            this.Comments = Member.GetComments();

            this.CodeLines = Member.FindSourceCode().Split("\r\n");

            this.CodeLineCount = Member.FindSourceCodeLineCount();
            this.CodeLineNumber = Member.FindSourceCodeLineNumber();

            this.CodeFilePath = Member.DeclaringType.FindClassFile();

            this.Attributes = Member.GetAttributes<Attribute>(IncludeBaseTypes: true);

            }
        }
    }