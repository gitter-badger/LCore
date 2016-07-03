using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Singularity.Context;
using System.Web.Mvc;
using Singularity.Annotations;

using LCore.Extensions;

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
        public string Token { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [FieldLoadFromQueryString]
        [FieldFocus]
        public string Text { get; set; }

        public bool? GlobalToken { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [HideManageViewColumn]
        public bool Active { get; set; }

        public override string ToString()
            {
            return this.Token ?? "";
            }

        public static string GetText(ModelContext DbContext, string Token, string DefaultText = "")
            {
            string Out = DefaultText;

            var Content = FindByToken(DbContext, Token);

            if (Content != null)
                Out = Content.Text;

            return Out;
            }

        public static IQueryable<TextContent> FindGlobalTokens(ModelContext DbContext)
            {
            return DbContext.GetDBSet<TextContent>().Where(
                t => t.Active &&
                    t.GlobalToken == true);
            }

        public static TextContent FindByToken(ModelContext DbContext, string Token)
            {
            Func<string, TextContent> Func = s =>
            {
                return DbContext.GetDBSet<TextContent>().FirstOrDefault(t => t.Token == Token && t.Active);
            };

            return Func.Cache("TextContentTokenCache")(Token);
            }
        }
    }