using System;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class CodeExplodeGenerics_ReplaceArguments : CodeExplodeGenerics
        {
        public int[] ArgIndexes;
        public string[] ArgNames;
        public string PreArgs;
        public string PostArgs;

        public CodeExplodeGenerics_ReplaceArguments(string Name, int[] ArgIndexes, string[] ArgNames,
            string Comments = "", string PreArgs = "", string PostArgs = "", int MaximumGeneric = CodeExplode_ExplodeLogic.ExplodeCount)
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
                Out.Add(CodeReplacements_Args($"{this.PreArgs}(", $"){this.PostArgs}", ";").Collect(s =>
                {
                    this.ArgIndexes.EachI((i, Index) =>
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
