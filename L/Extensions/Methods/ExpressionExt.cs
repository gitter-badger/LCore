using System;
using System.Linq.Expressions;

namespace LCore.Extensions
    {
    public static class ExpressionExt
        {
        /* TODO: L: Expression: Comment All Below */
        // TODO: L: Expression: Untested

        #region Extensions

        #region Not

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> In)
            {
            Func<T, bool> In2 = In.Compile();

            Expression<Func<T, bool>> Out = o => !In2(o);

            return Out;
            }

        #endregion

        #endregion
        }
    }