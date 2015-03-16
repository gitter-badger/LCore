using MVCL;
using MVCL.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace MVCL.Models
    {
    public class Error : IModel
        {
        [Key]
        public int ErrorID { get; set; }

        public DateTime Created { get; set; }

        public String Message { get; set; }
        public String URL { get; set; }

        public Boolean Active { get; set; }

        public String FullDetails { get; set; }

        public override string ToString()
            {
            return Created.ToString() + " " + Message;
            }
        }
    }
