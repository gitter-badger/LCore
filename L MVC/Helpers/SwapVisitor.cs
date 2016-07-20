using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LMVC.Extensions
    {
    public class SwapVisitor : ExpressionVisitor
        {
        private readonly Expression _From;
        private readonly Expression _To;

        public SwapVisitor(Expression From, Expression To)
            {
            this._From = From;
            this._To = To;
            }
        public override Expression Visit(Expression Node)
            {
            return Node == this._From ? this._To : base.Visit(Node);
            }
        }
    }