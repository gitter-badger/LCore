using System;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class CodeExplodeGenericsReplaceArguments : CodeExplodeGenerics
        {
        public readonly int[] ArgIndexes;
        public readonly string[] ArgNames;
        public readonly string PreArgs;
        public readonly string PostArgs;

        public CodeExplodeGenericsReplaceArguments(string Name, int[] ArgIndexes, string[] ArgNames,
            string Comments = "", string PreArgs = "", string PostArgs = "", int MaximumGeneric = CodeExplodeLogic.ExplodeCount)
            : base(Name, Comments, MaximumGeneric)
            {
            this.PreArgs = PreArgs;
            this.PostArgs = PostArgs;
            this.ArgIndexes = ArgIndexes;
            this.ArgNames = ArgNames;
            }

        public override List<List<string>> Replacements
            {
            get
                {
                List<List<string>> Out = base.Replacements;
                Out.Add(CodeReplacementsArgs($"{this.PreArgs}(", $"){this.PostArgs}", ";").Collect(s =>
                {
                    this.ArgIndexes.Each((i, Index) =>
                    {
                        s = s.Replace($"(o{(Index + 1).ToString()}, ", $"({this.ArgNames[i]}, ");
                        s = s.Replace($", o{(Index + 1).ToString()}, ", $", {this.ArgNames[i]}, ");
                        s = s.Replace($", o{(Index + 1).ToString()})", $", {this.ArgNames[i]})");
                        s = s.Replace($"(o{(Index + 1).ToString()})", $"({this.ArgNames[i]})");
                    });
                    return s;
                }));

                Out = this.Cutoff(Out);

                return Out;
                }
            }
        }
    }
