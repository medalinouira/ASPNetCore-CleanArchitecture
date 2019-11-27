/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using AutoMapper;
using System.Linq;
using ASPNetCore.CleanArchitecture.Data.Database;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore.CleanArchitecture.Infrastructure.Repositories
{
    public class GenericRepository<TModel, TEntity> : IGenericRepository<TModel, TEntity> where TModel : class where TEntity : class
    {
        #region Fields
        private readonly IMapper _iMapper;
        private readonly BaseDbContext _baseDbContext;
        #endregion

        #region Constructor
        public GenericRepository(
            IMapper _iMapper,
            BaseDbContext _baseDbContext)
        {
            this._iMapper = _iMapper;
            this._baseDbContext = _baseDbContext;
        }
        #endregion

        #region Methods

        #region Get
        public IList<TModel> GetAll()
        {
            var result = _baseDbContext.Set<TEntity>().ToList();
            return _iMapper.Map<IList<TModel>>(result);
        }
        public async Task<IList<TModel>> GetAllAsync()
        {
            var result = await _baseDbContext.Set<TEntity>().ToListAsync();
            return _iMapper.Map<IList<TModel>>(result);
        }
        public TModel GetById(object id)
        {
            var result = _baseDbContext.Set<TEntity>().Find(id);
            return _iMapper.Map<TModel>(result);
        }
        public async Task<TModel> GetByIdAsync(object id)
        {
            var result = await _baseDbContext.Set<TEntity>().FindAsync(id);
            return _iMapper.Map<TModel>(result);
        }
        #endregion

        #region Add
        public TModel Add(TModel modelToAdd)
        {
            var entityToAdd = _iMapper.Map<TEntity>(modelToAdd);
            var result = _baseDbContext.Add(entityToAdd);
            return _iMapper.Map<TModel>(result.Entity);
        }
        public async Task<TModel> AddAsync(TModel modelToAdd)
        {
            var entityToAdd = _iMapper.Map<TEntity>(modelToAdd);
            var result = await _baseDbContext.AddAsync(entityToAdd);
            return _iMapper.Map<TModel>(result.Entity);
        }
        public void AddRange(IList<TModel> modelsToAdd)
        {
            var entitiesToAdd = _iMapper.Map<TEntity>(modelsToAdd);
            _baseDbContext.AddRange(entitiesToAdd);
        }
        public async Task AddRangeAsync(IList<TModel> modelsToAdd)
        {
            var entitiesToAdd = _iMapper.Map<TEntity>(modelsToAdd);
            await _baseDbContext.AddRangeAsync(entitiesToAdd);
        }
        #endregion

        #region Update
        public void Update(TModel modelToUpdate)
        {
            var entityToUpdate = _iMapper.Map<TEntity>(modelToUpdate);
            _baseDbContext.Update(entityToUpdate);
        }
        public void UpdateRange(IList<TModel> modelsToUpdate)
        {
            var entitiesToUpdate = _iMapper.Map<TEntity>(modelsToUpdate);
            _baseDbContext.UpdateRange(entitiesToUpdate);
        }
        #endregion

        #region Delete
        public void DeleteById(object id)
        {
            var entityToDelete = this.GetById(id);
            _baseDbContext.Remove(entityToDelete);
        }
        public void Delete(TModel modelToDelete)
        {
            var entityToDelete = _iMapper.Map<TEntity>(modelToDelete);
            _baseDbContext.Remove(entityToDelete);
        }
        public void DeleteRange(IList<TModel> modelsToDelete)
        {
            var entitiesToDelete = _iMapper.Map<TEntity>(modelsToDelete);
            _baseDbContext.RemoveRange(entitiesToDelete);
        }
        #endregion

        #region Global
        public bool Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseDbContext.Set<TEntity>().Any(predicate);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _baseDbContext.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return _baseDbContext.SaveChanges();
        }
        #endregion

        #endregion
    }
}
