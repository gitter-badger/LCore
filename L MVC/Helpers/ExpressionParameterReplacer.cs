using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LMVC.Extensions
    {
    public class ExpressionParameterReplacer : ExpressionVisitor
        {
        public ExpressionParameterReplacer(IList<ParameterExpression> FromParameters, IList<ParameterExpression> ToParameters)
            {
            this.ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();

            for (int Index = 0; Index != FromParameters.Count && Index != ToParameters.Count; Index++)
                this.ParameterReplacements.Add(FromParameters[Index], ToParameters[Index]);
            }

        private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; }
        protected override Expression VisitParameter(ParameterExpression Node)
            {
            ParameterExpression Replacement;

            if (this.ParameterReplacements.TryGetValue(Node, out Replacement))
                Node = Replacement;

            return base.VisitParameter(Node);
            }
        }
    }