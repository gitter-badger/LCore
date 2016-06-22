using System.Web;

namespace Singularity.Models
    {
    public class TemplateViewModel
        {
        public string Token { get; set; }
        public string DefaultText { get; set; }

        public object[] ContextData { get; set; }

        public bool ShowText { get; set; }

        public bool AutoCreate { get; set; }

        public TemplateViewModel(string Token, IHtmlString DefaultText, object[] ContextData = null, bool ShowText = true)
            : this(Token, DefaultText.ToHtmlString(), ContextData, ShowText)
            {
            }

        public TemplateViewModel(string Token, string DefaultText = "", object[] ContextData = null, bool ShowText = true)
            {
            this.ShowText = ShowText;

            this.Token = Token;
            this.DefaultText = DefaultText;
            this.ContextData = ContextData ?? new object[] { };
            }
        }
    }