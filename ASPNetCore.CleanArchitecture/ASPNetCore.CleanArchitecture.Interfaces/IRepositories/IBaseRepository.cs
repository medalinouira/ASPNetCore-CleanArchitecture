/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ASPNetCore.CleanArchitecture.Interfaces.IRepositories
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        #region Get
        TModel GetById(object id);
        Task<TModel> GetByIdAsync(object id);
        IList<TModel> GetAll();
        Task<IList<TModel>> GetAllAsync();
        #endregion

        #region Add
        TModel Add(TModel modelToAdd);
        Task<TModel> AddAsync(TModel modelToAdd);
        void AddRange(IList<TModel> modelsToAdd);
        Task AddRangeAsync(IList<TModel> modelsToAdd);
        #endregion

        #region Update
        void Update(TModel modelToUpdate);
        void UpdateRange(IList<TModel> modelsToUpdate);
        #endregion

        #region Delete
        void DeleteById(object id);
        void Delete(TModel modelToDelete);
        void DeleteRange(IList<TModel> modelsToDelete);
        #endregion

        #region Global
        Task<int> SaveChangesAsync();
        bool Exist(Expression<Func<object, bool>> predicate);
        #endregion
    }
}
