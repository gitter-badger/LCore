using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singularity;
using System.Web.Mvc;
using System.Web;

namespace Singularity.Models
    {
    public class TemplateViewModel
        {
        public String Token { get; set; }
        public String DefaultText { get; set; }

        public Object[] ContextData { get; set; }

        public Boolean ShowText { get; set; }

        public Boolean AutoCreate { get; set; }

        public TemplateViewModel(String Token, MvcHtmlString DefaultText, Object[] ContextData = null, Boolean ShowText = true)
            : this(Token, DefaultText.ToHtmlString(), ContextData)
            {
            }

        public TemplateViewModel(String Token, String DefaultText = "", Object[] ContextData = null, Boolean ShowText = true)
            {
            this.ShowText = ShowText;

            this.Token = Token;
            this.DefaultText = DefaultText;
            this.ContextData = ContextData ?? new Object[] { };
            }
        }
    }