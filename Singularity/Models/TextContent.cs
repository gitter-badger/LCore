using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity;
using Singularity.Context;

namespace Singularity.Models
    {
    [FriendlyModelName("Text Content")]
    public class TextContent : IModel
        {
        [Key]
        public int TextContentID { get; set; }

        [Required]
        public String Token { get; set; }

        [DataType(DataType.MultilineText)]
        public String Text { get; set; }

        public Boolean Active { get; set; }

        public TextContent()
            {
            }

        public override string ToString()
            {
            return (Token ?? "").ToString();
            }

        public static String GetText(ModelContext Context, String Token, String DefaultText = "")
            {
            String Out = DefaultText;

            TextContent Content = Context.GetDBSet<TextContent>().Where(t => t.Token == Token && t.Active == true).FirstOrDefault();

            if (Content != null)
                Out = Content.Text;

            return Out;
            }
        }
    }