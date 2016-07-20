using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using LMVC.Context;
using System.Web.Mvc;
using LMVC.Annotations;

using LCore.Extensions;

namespace LMVC.Models
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
                Content => Content.Active &&
                    Content.GlobalToken == true);
            }

        public static TextContent FindByToken(ModelContext DbContext, string Token)
            {
            Func<string, TextContent> Func = Str =>
            {
                return DbContext.GetDBSet<TextContent>().FirstOrDefault(Text => Text.Token == Str && Text.Active);
            };

            // Token is cached not DbContext
            return Func.Cache("TextContentTokenCache")(Token);
            }
        }
    }