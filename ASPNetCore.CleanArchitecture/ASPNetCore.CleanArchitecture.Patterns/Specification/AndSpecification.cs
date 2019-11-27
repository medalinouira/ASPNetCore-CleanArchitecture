/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using System.Linq.Expressions;

namespace ASPNetCore.CleanArchitecture.Patterns.Specification
{
    internal sealed class AndSpecification<T> : AbstractSpecification<T>
    {
        #region Fields
        private readonly AbstractSpecification<T> _left;
        private readonly AbstractSpecification<T> _right;
        #endregion

        #region Constructor
        public AndSpecification(AbstractSpecification<T> _left,
            AbstractSpecification<T> _right)
        {
            this._left = _left;
            this._right = _right;
        }
        #endregion

        #region Methods
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> _leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> _rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.AndAlso(_leftExpression, _rightExpression);
            return Expression.Lambda<Func<T, bool>>(andExpression, _leftExpression.Parameters.Single());
        }
        #endregion
    }
}
