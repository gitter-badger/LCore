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
    public class TextContentViewModel
        {
        public String Token { get; set; }
        public String DefaultText { get; set; }

        public Object[] ContextData { get; set; }

        public Boolean ShowText { get; set; }

        public Boolean AutoCreate { get; set; }

        public TextContentViewModel(String Token, MvcHtmlString DefaultText, Object[] ContextData = null, Boolean ShowText = true, Boolean AutoCreate = false)
            : this(Token, DefaultText.ToHtmlString(), ContextData, ShowText, AutoCreate)
            {
            }

        public TextContentViewModel(String Token, String DefaultText = "", Object[] ContextData = null, Boolean ShowText = true, Boolean AutoCreate = false)
            {
            this.ShowText = ShowText;

            this.Token = Token;
            this.DefaultText = DefaultText;
            this.AutoCreate = AutoCreate;
            this.ContextData = ContextData ?? new Object[] { };
            }
        }
    }