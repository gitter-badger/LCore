using LMVC.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCore.Extensions;

namespace LMVC.Models
    {
    [DisplayColumn("Message", "Created", true)]
    public class Error : IModel
        {
        [Key]
        public int ErrorID { get; set; }

        public DateTime Created { get; set; }

        public string Message { get; set; }

        [HideManageViewColumn]
        public string URL { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        [NotMapped]
        public string ErrorFile
            {
            get
                {
                try
                    {
                    int AtIndex = this.FullDetails.IndexOf(" at ") + 4;
                    int InIndex = AtIndex + this.FullDetails.Substring(AtIndex).IndexOf(" in ") + 4;
                    int LineIndex = InIndex + this.FullDetails.Substring(InIndex).IndexOf(":line ");

                    if (LineIndex - InIndex <= 0)
                        return "";

                    string FullFile = this.FullDetails.Sub(InIndex, LineIndex - InIndex);

                    return FullFile.Substring(FullFile.LastIndexOf('\\') + 1);
                    }
                catch
                    {
                    return "";
                    }
                }
            }

        [NotMapped]
        public int? ErrorLine
            {
            get
                {
                try
                    {
                    int AtIndex = this.FullDetails.IndexOf(" at ") + 4;
                    int InIndex = AtIndex + this.FullDetails.Substring(AtIndex).IndexOf(" in ") + 4;
                    int LineIndex = InIndex + this.FullDetails.Substring(InIndex).IndexOf(":line ") + 6;

                    string Line = this.FullDetails.Substring(LineIndex);
                    Line = Line.Sub(0, Line.IndexOf(' '));

                    int Out;

                    int.TryParse(Line, out Out);

                    if (Out > 0)
                        return Out;

                    return null;
                    }
                catch
                    {
                    return null;
                    }
                }
            }

        [NotMapped]
        public string ErrorFunction
            {
            get
                {
                try
                    {
                    int AtIndex = this.FullDetails.IndexOf(" at ") + 4;
                    int InIndex = AtIndex + this.FullDetails.Substring(AtIndex).IndexOf(" in ");

                    if (InIndex - AtIndex <= 0)
                        return "";

                    string Function = this.FullDetails.Sub(AtIndex, InIndex - AtIndex);

                    Function = Function.Sub(Function.LastIndexOf('.') + 1);
                    Function = Function.Sub(0, Function.IndexOf('('));

                    return Function;
                    }
                catch
                    {
                    return "";
                    }
                }
            }

        public string FullDetails { get; set; }

        public override string ToString()
            {
            return $"{this.Created} {this.Message}";
            }
        }
    }
