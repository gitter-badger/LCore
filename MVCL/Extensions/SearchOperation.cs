using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using LCore;
using System.ComponentModel.DataAnnotations;

namespace MVCL
    {
    public class SearchOperation
        {
        public String Property { get; set; }
        public String OperatorStr { get; set; }
        public Func<Expression, Expression, Expression> Operator { get; set; }
        public String Search { get; set; }
        }
    }
