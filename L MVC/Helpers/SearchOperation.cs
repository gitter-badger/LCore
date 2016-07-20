using System;
using System.Linq.Expressions;

namespace LMVC.Extensions
    {
    public class SearchOperation
        {
        public string Property { get; set; }
        public string OperatorStr { get; set; }
        public Func<Expression, Expression, Expression> Operator { get; set; }
        public string Search { get; set; }
        }
    }
