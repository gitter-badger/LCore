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
using System.Web.Mvc;
using Singularity.Annotations;
using LCore;

namespace Singularity.Models
    {
    [FriendlyModelName("Text Content")]
    public class TextContent : IModel
        {
        [Key]
        public int TextContentID { get; set; }

        [Required]
        [FieldLoadFromQueryString]
        [FieldFocus]
        public String Token { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [FieldLoadFromQueryString]
        [FieldFocus]
        public String Text { get; set; }

        public Boolean? GlobalToken { get; set; }

        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [HideManageViewColumn]
        public Boolean Active { get; set; }

        public TextContent()
            {
            }

        public override string ToString()
            {
            return (Token ?? "").ToString();
            }

        public static String GetText(ModelContext DbContext, String Token, String DefaultText = "")
            {
            String Out = DefaultText;

            TextContent Content = FindByToken(DbContext, Token);

            if (Content != null)
                Out = Content.Text;

            return Out;
            }

        public static IQueryable<TextContent> FindGlobalTokens(ModelContext DbContext)
            {
            return DbContext.GetDBSet<TextContent>().Where(
                t => t.Active == true &&
                    t.GlobalToken == true);
            }

        public static TextContent FindByToken(ModelContext DbContext, String Token)
            {
            Func<String, TextContent> Func = (s) =>
            {
                return DbContext.GetDBSet<TextContent>().Where(
                t => t.Token == Token &&
                    t.Active == true).FirstOrDefault();
            };

            return Func.Cache("TextContentTokenCache")(Token);
            }
        }
    }