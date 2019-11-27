/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;
using System.Collections.Generic;

namespace ASPNetCore.CleanArchitecture.Domain.Services
{
    public class BaseService<TModel> : IBaseService<TModel>
        where TModel : class
    {
        #region Fields
        private readonly IBaseRepository<TModel> _iBaseRepository;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<TModel> _iBaseRepository)
        {
            this._iBaseRepository = _iBaseRepository;
        }
        #endregion

        #region Methods
        public TModel Add(TModel modelToAdd)
        {
            return _iBaseRepository.Add(modelToAdd);
        }

        public async Task<TModel> AddAsync(TModel modelToAdd)
        {
            return await _iBaseRepository.AddAsync(modelToAdd);
        }

        public void AddRange(IList<TModel> modelsToAdd)
        {
            _iBaseRepository.AddRange(modelsToAdd);
        }

        public void Delete(TModel modelToDelete)
        {
            _iBaseRepository.Delete(modelToDelete);
        }

        public void DeleteById(object id)
        {
            _iBaseRepository.DeleteById(id);
        }

        public void DeleteRange(IList<TModel> modelsToDelete)
        {
            _iBaseRepository.DeleteRange(modelsToDelete);
        }

        public bool Exist(Expression<Func<Object, bool>> predicate)
        {
            return _iBaseRepository.Exist(predicate);
        }

        public IList<TModel> GetAll()
        {
            return _iBaseRepository.GetAll();
        }

        public async Task<IList<TModel>> GetAllAsync()
        {
            return await _iBaseRepository.GetAllAsync();
        }

        public TModel GetById(object id)
        {
            return _iBaseRepository.GetById(id);
        }

        public async Task<TModel> GetByIdAsync(object id)
        {
            return await _iBaseRepository.GetByIdAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _iBaseRepository.SaveChangesAsync();
        }

        public void Update(TModel modelToUpdate)
        {
            _iBaseRepository.Update(modelToUpdate);
        }

        public void UpdateRange(IList<TModel> modelsToUpdate)
        {
            _iBaseRepository.UpdateRange(modelsToUpdate);
        }
        #endregion
    }
}
