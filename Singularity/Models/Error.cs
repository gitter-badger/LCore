using Singularity;
using Singularity.Annotations;
using Singularity.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace Singularity.Models
    {
    [DisplayColumn("Message", "Created", true)]
    public class Error : IModel
        {
        [Key]
        public int ErrorID { get; set; }

        public DateTime Created { get; set; }

        public String Message { get; set; }

        [HideManageViewColumn]
        public String URL { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        [NotMapped]
        public String ErrorFile
            {
            get
                {
                try
                    {
                    int AtIndex = FullDetails.IndexOf(" at ") + 4;
                    int InIndex = AtIndex + FullDetails.Substring(AtIndex).IndexOf(" in ") + 4;
                    int LineIndex = InIndex + FullDetails.Substring(InIndex).IndexOf(":line ");

                    if (LineIndex - InIndex <= 0)
                        return "";

                    String FullFile = FullDetails.Substring(InIndex, LineIndex - InIndex);

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
                    int AtIndex = FullDetails.IndexOf(" at ") + 4;
                    int InIndex = AtIndex + FullDetails.Substring(AtIndex).IndexOf(" in ") + 4;
                    int LineIndex = InIndex + FullDetails.Substring(InIndex).IndexOf(":line ") + 6;

                    String Line = FullDetails.Substring(LineIndex);
                    Line = Line.Substring(0, Line.IndexOf(' '));

                    int Out = -1;

                    Int32.TryParse(Line, out Out);

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
        public String ErrorFunction
            {
            get
                {
                try
                    {
                    int AtIndex = FullDetails.IndexOf(" at ") + 4;
                    int InIndex = AtIndex + FullDetails.Substring(AtIndex).IndexOf(" in ");

                    if (InIndex - AtIndex <= 0)
                        return "";

                    String Function = FullDetails.Substring(AtIndex, InIndex - AtIndex);

                    Function = Function.Substring(Function.LastIndexOf('.') + 1);
                    Function = Function.Substring(0, Function.IndexOf('('));

                    return Function;
                    }
                catch
                    {
                    return "";
                    }
                }
            }

        public String FullDetails { get; set; }

        public override string ToString()
            {
            return Created.ToString() + " " + Message;
            }
        }
    }
