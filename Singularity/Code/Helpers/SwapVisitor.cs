using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Singularity.Extensions
    {
    public class SwapVisitor : ExpressionVisitor
        {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
            {
            this.from = from;
            this.to = to;
            }
        public override Expression Visit(Expression node)
            {
            return node == this.from ? this.to : base.Visit(node);
            }
        }
    }