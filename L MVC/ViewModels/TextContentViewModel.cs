using System.Web;

namespace LMVC.Models
    {
    public class TextContentViewModel
        {
        public string Token { get; set; }
        public string DefaultText { get; set; }

        public object[] ContextData { get; set; }

        public bool ShowText { get; set; }

        public bool AutoCreate { get; set; }

        public TextContentViewModel(string Token, IHtmlString DefaultText, object[] ContextData = null, bool ShowText = true, bool AutoCreate = false)
            : this(Token, DefaultText.ToHtmlString(), ContextData, ShowText, AutoCreate)
            {
            }

        public TextContentViewModel(string Token, string DefaultText = "", object[] ContextData = null, bool ShowText = true, bool AutoCreate = false)
            {
            this.ShowText = ShowText;

            this.Token = Token;
            this.DefaultText = DefaultText;
            this.AutoCreate = AutoCreate;
            this.ContextData = ContextData ?? new object[] { };
            }
        }
    }