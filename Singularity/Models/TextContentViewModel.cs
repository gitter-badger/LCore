using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity;
using System.Web.Mvc;

namespace Singularity.Models
    {
    public class TextContentViewModel
        {
        public String Token { get; set; }
        public String DefaultText { get; set; }

        public Object[] ContextData { get; set; }

        public TextContentViewModel(String Token, MvcHtmlString DefaultText, Object[] ContextData = null)
            : this(Token, DefaultText.ToHtmlString(), ContextData) { }

        public TextContentViewModel(String Token, String DefaultText = "", Object[] ContextData = null)
            {
            this.Token = Token;
            this.DefaultText = DefaultText;
            this.ContextData = ContextData ?? new Object[] { };
            }
        }
    }