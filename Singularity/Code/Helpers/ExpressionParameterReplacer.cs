using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Singularity.Extensions
    {
    public class ExpressionParameterReplacer : ExpressionVisitor
        {
        public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
            {
            this.ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
            for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                this.ParameterReplacements.Add(fromParameters[i], toParameters[i]);
            }
        private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; }
        protected override Expression VisitParameter(ParameterExpression node)
            {
            ParameterExpression replacement;
            if (this.ParameterReplacements.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
            }
        }
    }