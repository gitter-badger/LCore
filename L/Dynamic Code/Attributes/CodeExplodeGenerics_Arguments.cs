using System;
using System.Collections.Generic;
using System.Text;

namespace LCore.Dynamic
    {
    public class CodeExplodeGenerics_ReplaceArguments : CodeExplodeGenerics
        {
        public int[] ArgIndexes = null;
        public String[] ArgNames = null;
        public String PreArgs = null;
        public String PostArgs = null;

        public CodeExplodeGenerics_ReplaceArguments(String Name, int[] ArgIndexes, String[] ArgNames,
            String Comments = "", String PreArgs = "", String PostArgs = "", int MaximumGeneric = CodeExplode_ExplodeLogic.ExplodeCount)
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
                List<List<String>> Out = base.Replacements;
                Out.Add(CodeExplodeGenerics.CodeReplacements_Args(PreArgs + "(", ")" + PostArgs, ";").Collect((s) =>
                {
                    ArgIndexes.EachI((i, Index) =>
                    {
                        s = s.Replace("(o" + (Index + 1).ToString() + ", ", "(" + ArgNames[i] + ", ");
                        s = s.Replace(", o" + (Index + 1).ToString() + ", ", ", " + ArgNames[i] + ", ");
                        s = s.Replace(", o" + (Index + 1).ToString() + ")", ", " + ArgNames[i] + ")");
                        s = s.Replace("(o" + (Index + 1).ToString() + ")", "(" + ArgNames[i] + ")");
                    });
                    return s;
                }));

                Out = Cutoff(Out);

                return Out;
                }
            }
        }
    }
