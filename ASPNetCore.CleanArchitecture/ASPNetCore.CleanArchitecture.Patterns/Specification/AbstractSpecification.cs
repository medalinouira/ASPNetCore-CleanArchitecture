/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq.Expressions;

namespace ASPNetCore.CleanArchitecture.Patterns.Specification
{
    public abstract class AbstractSpecification<T>
    {
        #region Fields 
        public static readonly AbstractSpecification<T> All = new IdentitySpecification<T>();
        public abstract Expression<Func<T, bool>> ToExpression();
        #endregion

        #region Methods
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
        public AbstractSpecification<T> And(AbstractSpecification<T> specification)
        {
            if (this == All)
            {
                return specification;
            }
            if (specification == All)
            {
                return this;
            }
            return new AndSpecification<T>(this, specification);
        }
        public AbstractSpecification<T> Or(AbstractSpecification<T> specification)
        {
            if (this == All || specification == All)
            {
                return All;
            }
            return new OrSpecification<T>(this, specification);
        }
        public AbstractSpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
        #endregion
    }
}
