/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using System.Linq.Expressions;

namespace ASPNetCore.CleanArchitecture.Patterns.Specification
{
    internal sealed class NotSpecification<T> : AbstractSpecification<T>
    {
        #region Fields
        private readonly AbstractSpecification<T> _specification;
        #endregion

        #region Constructor
        public NotSpecification(AbstractSpecification<T> _specification)
        {
            this._specification = _specification;
        }
        #endregion

        #region Methods
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> _expression = _specification.ToExpression();

            UnaryExpression notExpression = Expression.Not(_expression.Body);
            return Expression.Lambda<Func<T, bool>>(notExpression, _expression.Parameters.Single());
        }
        #endregion
    }
}
