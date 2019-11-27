/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq.Expressions;

namespace ASPNetCore.CleanArchitecture.Patterns.Specification
{
    public class GenericSpecification<T>
    {
        #region Fields
        private readonly Expression<Func<T, bool>> _expression;
        #endregion

        #region Constructor
        public GenericSpecification(Expression<Func<T, bool>> _expression)
        {
            this._expression = _expression;
        }
        #endregion

        #region Methods
        public bool IsSatisfiedBy(T entity)
        {
            return _expression.Compile().Invoke(entity);
        }
        #endregion
    }
}
