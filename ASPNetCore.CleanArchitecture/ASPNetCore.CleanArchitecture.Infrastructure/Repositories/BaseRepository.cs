/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using AutoMapper;
using System.Linq;
using ASPNetCore.CleanArchitecture.Data.Database;
using ASPNetCore.CleanArchitecture.Models.Attributs;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;
using System.Collections.Generic;

namespace ASPNetCore.CleanArchitecture.Infrastructure.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        #region Fields
        private readonly IMapper _iMapper;
        private readonly BaseDbContext _dbContext;
        private readonly dynamic _iGenericRepository;
        #endregion

        #region Constructor
        public BaseRepository(IMapper _iMapper,
            BaseDbContext _dbContext)
        {
            this._iMapper = _iMapper;
            this._dbContext = _dbContext;

            _iGenericRepository = InitGenericRepository();
        }
        #endregion

        #region Methods        

        #region Get
        public IList<TModel> GetAll()
        {
            return _iGenericRepository.GetAll();
        }
        public async Task<IList<TModel>> GetAllAsync()
        {
            return await _iGenericRepository.GetAllAsync();
        }
        public TModel GetById(object id)
        {
            return _iGenericRepository.GetById(id);
        }
        public async Task<TModel> GetByIdAsync(object id)
        {
            return await _iGenericRepository.GetByIdAsync(id);
        }
        #endregion

        #region Add
        public TModel Add(TModel modelToAdd)
        {
            return _iGenericRepository.Add(modelToAdd);
        }
        public async Task<TModel> AddAsync(TModel modelToAdd)
        {
            return await _iGenericRepository.AddAsync(modelToAdd);
        }
        public void AddRange(IList<TModel> modelsToAdd)
        {
            _iGenericRepository.AddRange(modelsToAdd);
        }
        public async Task AddRangeAsync(IList<TModel> modelsToAdd)
        {
            await _iGenericRepository.AddRangeAsync(modelsToAdd);
        }
        #endregion

        #region Update
        public void Update(TModel modelToUpdate)
        {
            _iGenericRepository.Update(modelToUpdate);
        }
        public void UpdateRange(IList<TModel> modelsToUpdate)
        {
            _iGenericRepository.UpdateRange(modelsToUpdate);
        }
        #endregion

        #region Delete
        public void DeleteById(object id)
        {
            _iGenericRepository.DeleteById(id);
        }
        public void Delete(TModel modelToDelete)
        {
            _iGenericRepository.Delete(modelToDelete);
        }
        public void DeleteRange(IList<TModel> modelsToDelete)
        {
            _iGenericRepository.DeleteRange(modelsToDelete);
        }
        #endregion

        #region Global
        public bool Exist(Expression<Func<Object, bool>> predicate)
        {
            return _iGenericRepository.Exist(predicate);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _iGenericRepository.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return _iGenericRepository.SaveChanges();
        }
        #endregion

        private dynamic InitGenericRepository()
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(typeof(TModel));
            var entityNameAttr = attrs.Where(attr => attr is EntityNameAttribute).FirstOrDefault() as EntityNameAttribute;
            var entityName = entityNameAttr.GetEntityName();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var entityType = (from elem in (from app in assemblies
                                            select (from tip in app.GetTypes()
                                                    where tip.Name == entityName.Trim()
                                                    select tip).FirstOrDefault())
                              where elem != null
                              select elem).FirstOrDefault();

            Type abstractDAOType = typeof(GenericRepository<,>).MakeGenericType(typeof(TModel), entityType);
            return Activator.CreateInstance(abstractDAOType, _iMapper, _dbContext);
        }
        #endregion
    }
}
